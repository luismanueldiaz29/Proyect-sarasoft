create tablespace proyectoBD datafile 'C:\app\AISM\product\18.0.0\oradata\XE\proyectoBD.dbf' size 40 M;
create user sarasoft identified by "1234" default tablespace proyectoBD temporary tablespace temp quota unlimited on proyectoBD;
create role privilegios;
grant create session, create table, select any table, update any table, create role, create public synonym to privilegios with admin option;
grant create any trigger, create any procedure to privilegios;
commit;
grant privilegios to sarasoft;
connect sarasoft/"1234"@localhost:1521/XEPDB1;

CREATE TABLE abono (
    codabono            INTEGER NOT NULL,
    fechacreacion       DATE NOT NULL,
    valorabono          NUMBER(9, 2) NOT NULL,
    cliente_idcliente   VARCHAR2(12) NOT NULL,
    cuenta_codcuenta    INTEGER NOT NULL
);

ALTER TABLE abono ADD CHECK ( valorabono > 0 );

ALTER TABLE abono ADD CONSTRAINT abono_pk PRIMARY KEY ( codabono );

CREATE TABLE cliente (
    idcliente   VARCHAR2(12) NOT NULL,
    nombre1     VARCHAR2(13) NOT NULL,
    nombre2     VARCHAR2(13) DEFAULT 'NO TIENE',
    apellido1   VARCHAR2(13) NOT NULL,
    apellido2   VARCHAR2(13) NOT NULL,
    direccion   VARCHAR2(50) NOT NULL,
    telefono1   VARCHAR2(12) DEFAULT 'NO TIENE',
    telefono2   VARCHAR2(12) DEFAULT 'NO TIENE',
    correo      VARCHAR2(30) DEFAULT 'NO TIENE'
);

ALTER TABLE cliente ADD CONSTRAINT cliente_pk PRIMARY KEY ( idcliente );

CREATE TABLE cuenta (
    codcuenta           INTEGER NOT NULL,
    fechacreacion       DATE NOT NULL,
    valordeuda          NUMBER(11, 2) DEFAULT 0 NOT NULL,
    estado              VARCHAR2(15) NOT NULL,
    saldoanterior       NUMBER(10, 2) DEFAULT 0 NOT NULL,
    totalabonos         NUMBER(11, 2) DEFAULT 0 NOT NULL,
    totalfacturas       NUMBER(11, 2) DEFAULT 0 NOT NULL,
    cliente_idcliente   VARCHAR2(12) NOT NULL
);

ALTER TABLE cuenta ADD CONSTRAINT cuenta_pk PRIMARY KEY ( codcuenta );

CREATE TABLE detalle (
    coddetalle             INTEGER NOT NULL,
    nombreproducto         VARCHAR2(20) NOT NULL,
    categoria              VARCHAR2(20) NOT NULL,
    cantidad               INTEGER NOT NULL,
    costo                  NUMBER(8, 2) NOT NULL,
    subtotal               NUMBER(8, 2) NOT NULL,
    factura_codfactura     INTEGER NOT NULL,
    producto_codproducto   INTEGER NOT NULL
);
ALTER TABLE detalle ADD presentacion VARCHAR2(30) NOT NULL;--*******

ALTER TABLE detalle ADD CHECK ( cantidad > 0 );

ALTER TABLE detalle ADD CHECK ( costo > 0 );

ALTER TABLE detalle ADD CONSTRAINT detalle_pk PRIMARY KEY ( coddetalle );

CREATE TABLE empleado (
    idvendedor        VARCHAR2(12) NOT NULL,
    primernombre      VARCHAR2(13) NOT NULL,
    segundonombre     VARCHAR2(13) DEFAULT 'NO TIENE',
    primerapellido    VARCHAR2(13) NOT NULL,
    segundoapellido   VARCHAR2(13) NOT NULL,
    cargo             VARCHAR2(15) NOT NULL,
    telefono1         VARCHAR2(12) DEFAULT 'NO TIENE',
    telefono2         VARCHAR2(12) DEFAULT 'NO TIENE',
    direccion         VARCHAR2(50) NOT NULL,
    contraseña        VARCHAR2(10) NOT NULL
);

ALTER TABLE empleado ADD CONSTRAINT empleado_pk PRIMARY KEY ( idvendedor );

CREATE TABLE factura (
    codfactura            INTEGER NOT NULL,
    fechacreacion         DATE NOT NULL,
    totalpagar            NUMBER(9, 2) NOT NULL,
    cliente_idcliente     VARCHAR2(12) NOT NULL,
    cuenta_codcuenta      INTEGER NOT NULL,
    empleado_idvendedor   VARCHAR2(12) NOT NULL
);

ALTER TABLE factura ADD CONSTRAINT factura_pk PRIMARY KEY ( codfactura );

CREATE TABLE producto (
    codproducto        INTEGER NOT NULL,
    nombre             VARCHAR2(20) NOT NULL,
    categoria          VARCHAR2(20) NOT NULL,
    costo              NUMBER(8, 2) NOT NULL,
    preciocompra       NUMBER(8, 2) NOT NULL,
    cantidadbodega     INTEGER NOT NULL,
    fechavencimiento   DATE NOT NULL
);
ALTER TABLE producto ADD presentacion VARCHAR2(30) NOT NULL;--****

ALTER TABLE producto ADD CHECK ( costo > 0 );

ALTER TABLE producto ADD CHECK ( preciocompra > 0 );

ALTER TABLE producto ADD CHECK ( cantidadbodega > 0 );

ALTER TABLE producto MODIFY fechavencimiento VARCHAR2(12) DEFAULT 'NO APLICA';--*********


ALTER TABLE producto ADD CONSTRAINT producto_pk PRIMARY KEY ( codproducto );

ALTER TABLE abono
    ADD CONSTRAINT abono_cliente_fk FOREIGN KEY ( cliente_idcliente )
        REFERENCES cliente ( idcliente );

ALTER TABLE abono
    ADD CONSTRAINT abono_cuenta_fk FOREIGN KEY ( cuenta_codcuenta )
        REFERENCES cuenta ( codcuenta );

ALTER TABLE cuenta
    ADD CONSTRAINT cuenta_cliente_fk FOREIGN KEY ( cliente_idcliente )
        REFERENCES cliente ( idcliente );

ALTER TABLE detalle
    ADD CONSTRAINT detalle_factura_fk FOREIGN KEY ( factura_codfactura )
        REFERENCES factura ( codfactura );

ALTER TABLE detalle
    ADD CONSTRAINT detalle_producto_fk FOREIGN KEY ( producto_codproducto )
        REFERENCES producto ( codproducto );

ALTER TABLE factura
    ADD CONSTRAINT factura_cliente_fk FOREIGN KEY ( cliente_idcliente )
        REFERENCES cliente ( idcliente );

ALTER TABLE factura
    ADD CONSTRAINT factura_cuenta_fk FOREIGN KEY ( cuenta_codcuenta )
        REFERENCES cuenta ( codcuenta );

ALTER TABLE factura
    ADD CONSTRAINT factura_empleado_fk FOREIGN KEY ( empleado_idvendedor )
        REFERENCES empleado ( idvendedor );
--------------------------------------------------------------------------------------------------------------------------------------------------------------------

--Creación de secuencia para la tabla de productos
create sequence sec_producto minvalue 1 start with 1 increment by 1;

--Creación de especificaciones de paquete producto
create or replace package pq_producto as

procedure guardar_producto(codproducto producto.codproducto%type,
nombre producto.nombre%type,
categoria producto.categoria%type,
costo producto.costo%type,
preciocompra producto.preciocompra%type,
cantidadbodega producto.cantidadbodega%type,
fechavencimiento producto.fechavencimiento%type,
presentacion producto.presentacion%type);

procedure modificar_producto(Tcodproducto producto.codproducto%type,
Tnombre producto.nombre%type,
Tcategoria producto.categoria%type,
Tcosto producto.costo%type,
Tpreciocompra producto.preciocompra%type,
Tcantidadbodega producto.cantidadbodega%type,
Tfechavencimiento producto.fechavencimiento%type,
Tpresentacion producto.presentacion%type);

end pq_producto;

--Creación del cuerpo del paquete producto
create or replace package body pq_producto as
procedure guardar_producto(codproducto producto.codproducto%type,
nombre producto.nombre%type,
categoria producto.categoria%type,
costo producto.costo%type,
preciocompra producto.preciocompra%type,
cantidadbodega producto.cantidadbodega%type,
fechavencimiento producto.fechavencimiento%type,
presentacion producto.presentacion%type) is 
begin
insert into producto
values (sec_producto.nextval,nombre,categoria,costo,preciocompra,cantidadbodega,fechavencimiento,presentacion);
commit;
end guardar_producto;

procedure modificar_producto(Tcodproducto producto.codproducto%type,
Tnombre producto.nombre%type,
Tcategoria producto.categoria%type,
Tcosto producto.costo%type,
Tpreciocompra producto.preciocompra%type,
Tcantidadbodega producto.cantidadbodega%type,
Tfechavencimiento producto.fechavencimiento%type,
Tpresentacion producto.presentacion%type) is
res number;
begin

update producto set nombre=Tnombre,categoria=Tcategoria,costo=Tcosto,preciocompra=Tpreciocompra,cantidadbodega=Tcantidadbodega,
fechavencimiento=Tfechavencimiento,presentacion=Tpresentacion where codproducto=Tcodproducto;
commit;

end modificar_producto;

end pq_producto;

--Especificaciones del paquete de clientes
create or replace package ControlCliente
is
procedure Guardarcliente
(
cedula cliente.idcliente%type,
nom1 cliente.nombre1%type,
nom2 cliente.nombre2%type,
ape1 cliente.apellido1%type,
ape2 cliente.apellido2%type,
tel1 cliente.telefono1%type,
tel2 cliente.telefono2%type,
dir cliente.direccion%type,
cor cliente.correo%type
);

procedure ModificarCliente
(
cedula cliente.idcliente%type,
Nom1 cliente.nombre1%type,
nom2 cliente.nombre2%type,
ape1 cliente.apellido1%type,
ape2 cliente.apellido2%type,
tel1 cliente.telefono1%type,
tel2 cliente.telefono2%type,
dir cliente.direccion%type,
cor cliente.correo%type
);


end;

--Cuerpo del paquete para clientes
create or replace package body ControlCliente
is
--procedimiento guadar cliente 
procedure Guardarcliente
(
cedula cliente.idcliente%type,
nom1 cliente.nombre1%type,
nom2 cliente.nombre2%type,
ape1 cliente.apellido1%type,
ape2 cliente.apellido2%type,
tel1 cliente.telefono1%type,
tel2 cliente.telefono2%type,
dir cliente.direccion%type,
cor cliente.correo%type
)
as
begin
insert into cliente values(cedula, nom1, nom2, ape1, ape2, tel1, tel2, dir, cor);
commit;
end;

--procedimiento Modificar cliente

procedure ModificarCliente
(
cedula cliente.idcliente%type,
Nom1 cliente.nombre1%type,
nom2 cliente.nombre2%type,
ape1 cliente.apellido1%type,
ape2 cliente.apellido2%type,
tel1 cliente.telefono1%type,
tel2 cliente.telefono2%type,
dir cliente.direccion%type,
cor cliente.correo%type
)
is
begin
update cliente set
nombre1= Nom1, nombre2 = nom2, apellido1 = ape1, apellido2 = ape2, telefono1 = tel1, telefono2 = tel2, correo = cor, direccion = dir
where idcliente = cedula;
end;

end;



--Especificaciones del paquete de vendedores
create or replace package ControlVendedor
is
procedure Guardarvendedor
(
    idvendedor  empleado.idvendedor%type,
    primernombre empleado.primernombre%type ,
    segundonombre empleado.segundonombre%type,
    primerapellido empleado.primerapellido%type,
    segundoapellido  empleado.segundoapellido%type,
    cargo  empleado.cargo%type,
    telefono1 empleado.telefono1%type,
    telefono2 empleado.telefono2%type,
    direccion  empleado.direccion%type,
    contraseña  empleado.contraseña%type
);

procedure Modificarvendedor
(
Tidvendedor  empleado.idvendedor%type,
    Tprimernombre empleado.primernombre%type ,
    Tsegundonombre empleado.segundonombre%type,
    Tprimerapellido empleado.primerapellido%type,
    Tsegundoapellido  empleado.segundoapellido%type,
    Tcargo  empleado.cargo%type,
    Ttelefono1 empleado.telefono1%type,
    Ttelefono2 empleado.telefono2%type,
    Tdireccion  empleado.direccion%type,
    Tcontraseña  empleado.contraseña%type
);


end;

--Cuerpo del paquete para vendedores
create or replace package body Controlvendedor
is
--procedimiento guadar vendedor 
procedure Guardarvendedor
(
idvendedor  empleado.idvendedor%type,
    primernombre empleado.primernombre%type ,
    segundonombre empleado.segundonombre%type,
    primerapellido empleado.primerapellido%type,
    segundoapellido  empleado.segundoapellido%type,
    cargo  empleado.cargo%type,
    telefono1 empleado.telefono1%type,
    telefono2 empleado.telefono2%type,
    direccion  empleado.direccion%type,
    contraseña  empleado.contraseña%type
)
as
begin
insert into empleado values(idvendedor, primernombre, segundonombre, primerapellido, segundoapellido, cargo, telefono1, telefono2, direccion, contraseña);
commit;
end;

--procedimiento Modificar vendedor

procedure Modificarvendedor
(
Tidvendedor  empleado.idvendedor%type,
    Tprimernombre empleado.primernombre%type ,
    Tsegundonombre empleado.segundonombre%type,
    Tprimerapellido empleado.primerapellido%type,
    Tsegundoapellido  empleado.segundoapellido%type,
    Tcargo  empleado.cargo%type,
    Ttelefono1 empleado.telefono1%type,
    Ttelefono2 empleado.telefono2%type,
    Tdireccion  empleado.direccion%type,
    Tcontraseña  empleado.contraseña%type
)
is
begin
update empleado set
primernombre= Tprimernombre, segundonombre = Tsegundonombre, primerapellido = Tprimerapellido, segundoapellido = Tsegundoapellido,
cargo = Tcargo, telefono1 = Ttelefono1, telefono2 = Ttelefono2,  direccion = Tdireccion, contraseña = Tcontraseña where idvendedor = Tidvendedor;
end;

end;

--Creación de secuencia para la tabla de cuentas
create sequence sec_cuenta minvalue 3 start with 3 increment by 1;


--Especificaciones del paquete de cuentas
create or replace package ControlCuenta
is
procedure Guardarcuenta
(
    codcuenta  cuenta.codcuenta%type,
    fechacreacion cuenta.fechacreacion%type ,
    valordeuda cuenta.valordeuda%type,
    estado cuenta.estado%type,
    saldoanterior  cuenta.saldoanterior%type,
    totalabonos  cuenta.totalabonos%type,
    totalfacturas cuenta.totalfacturas%type,
    cliente_idcliente cuenta.cliente_idcliente%type
);

end;

--Cuerpo del paquete para cuentas
create or replace package body Controlcuenta
is
--procedimiento guadar cuenta 
procedure Guardarcuenta
(
codcuenta  cuenta.codcuenta%type,
    fechacreacion cuenta.fechacreacion%type ,
    valordeuda cuenta.valordeuda%type,
    estado cuenta.estado%type,
    saldoanterior  cuenta.saldoanterior%type,
    totalabonos  cuenta.totalabonos%type,
    totalfacturas cuenta.totalfacturas%type,
    cliente_idcliente cuenta.cliente_idcliente%type
)
as
begin
insert into cuenta values(sec_cuenta.nextval, sysdate, valordeuda, estado, saldoanterior, totalabonos, totalfacturas, cliente_idcliente);
commit;
end;

end;

--Creación de secuencias para factura y detalle
create sequence sec_factura minvalue 5 start with 5 increment by 1;
create sequence sec_detalle minvalue 5 start with 5 increment by 1;

--Especificaciones del paquete de facturación
create or replace package facturacion
is
procedure Guardarfactura
(
    codfactura  factura.codfactura%type,
    fechacreacion factura.fechacreacion%type ,
    totalpagar factura.totalpagar%type,
    cliente_idcliente factura.cliente_idcliente%type,
    cuenta_codcuenta  factura.cuenta_codcuenta%type,
    empleado_idvendedor  factura.empleado_idvendedor%type
);

procedure Guardardetalle
(
    coddetalle  detalle.coddetalle%type,
    nombreproducto detalle.nombreproducto%type,
    categoria  detalle.categoria%type,
    cantidad  detalle.cantidad%type,
    costo  detalle.costo%type,
    subtotal detalle.subtotal%type,
    factura_codfactura detalle.factura_codfactura%type,
    producto_codproducto detalle.producto_codproducto%type,
    presentacion detalle.presentacion%type
);

procedure actualizarstock(Tcodproducto detalle.producto_codproducto%type, cantidad detalle.cantidad%type);

procedure nuevacuenta(
    fechacreacion cuenta.fechacreacion%type ,

    Tcliente_idcliente cuenta.cliente_idcliente%type
);

FUNCTION saldoanterior(idcliente cuenta.cliente_idcliente%type) RETURN NUMBER;

end;

--Cuerpo del paquete para facturación
create or replace package body facturacion
is
codigofactura number := 0;
codigodetalle number := 0;
codigocuenta number := 0;
--procedimiento guadar factura 
procedure Guardarfactura
(
codfactura  factura.codfactura%type,
    fechacreacion factura.fechacreacion%type ,
    totalpagar factura.totalpagar%type,
    cliente_idcliente factura.cliente_idcliente%type,
    cuenta_codcuenta  factura.cuenta_codcuenta%type,
    empleado_idvendedor  factura.empleado_idvendedor%type
)
as
begin
codigocuenta := cuenta_codcuenta;
codigofactura := sec_factura.nextval;
insert into factura values(codigofactura, sysdate, totalpagar, cliente_idcliente, cuenta_codcuenta, empleado_idvendedor);
commit;
end;

procedure Guardardetalle
(
    coddetalle  detalle.coddetalle%type,
    nombreproducto detalle.nombreproducto%type,
    categoria  detalle.categoria%type,
    cantidad  detalle.cantidad%type,
    costo  detalle.costo%type,
    subtotal detalle.subtotal%type,
    factura_codfactura detalle.factura_codfactura%type,
    producto_codproducto detalle.producto_codproducto%type,
    presentacion detalle.presentacion%type
)
as
begin
codigodetalle := sec_detalle.nextval;
insert into detalle values(codigodetalle, nombreproducto, categoria, cantidad, costo, subtotal, codigofactura, producto_codproducto, presentacion);
actualizarstock(producto_codproducto, cantidad);
commit;
end;

procedure actualizarstock(Tcodproducto detalle.producto_codproducto%type, cantidad detalle.cantidad%type) as
begin
update producto set cantidadbodega = cantidadbodega - cantidad where codproducto = Tcodproducto;
commit;
end;

procedure nuevacuenta
(

    fechacreacion cuenta.fechacreacion%type ,
   
    Tcliente_idcliente cuenta.cliente_idcliente%type
)
as
deuda cuenta.valordeuda%type;
begin
deuda := facturacion.saldoanterior(Tcliente_idcliente);
update cuenta set estado = 'Inactiva' where cliente_idcliente = Tcliente_idcliente and estado = 'Activa';
insert into cuenta 
values (sec_cuenta.nextval, sysdate, deuda, 'Activa', deuda, 0, 0,Tcliente_idcliente);
commit;
end;

FUNCTION saldoanterior(idcliente cuenta.cliente_idcliente%type) RETURN NUMBER is
deuda cuenta.valordeuda%type;
begin
select valordeuda into deuda from cuenta where cliente_idcliente = idcliente and estado = 'Activa';
return deuda;
EXCEPTION
when NO_DATA_FOUND THEN
RETURN 0;
END;

end facturacion;

--trigger para actualizar el total de las facturas y el valor de la deuda en una cuenta
create or replace TRIGGER tr_actualizarTotalesCuenta
AFTER INSERT ON factura
FOR EACH ROW
DECLARE
BEGIN
UPDATE cuenta SET totalfacturas=totalfacturas + :new.totalpagar where codcuenta=:new.cuenta_codcuenta;
UPDATE cuenta SET valordeuda=totalfacturas + saldoanterior - totalabonos where codcuenta=:new.cuenta_codcuenta;
END;

--Creación de secuencia para la tabla de abonos
create sequence sec_abono minvalue 1 start with 1 increment by 1;


--Especificaciones del paquete de abonos
create or replace package Controlabono
is
procedure Guardarabono
(
    fechacreacion abono.fechacreacion%type ,
    valorabono abono.valorabono%type,
    Tcliente_idcliente abono.cliente_idcliente%type,
    cocuenta abono.cuenta_codcuenta%type
);

FUNCTION buscarcliente(idcliente cuenta.cliente_idcliente%type) RETURN NUMBER;

FUNCTION validarabono(Tvalorabono abono.valorabono%type, idcliente cuenta.cliente_idcliente%type) RETURN NUMBER;

end;

--Cuerpo del paquete para abonos
create or replace package body Controlabono
is
--procedimiento guadar abonos 
procedure Guardarabono
(
    fechacreacion abono.fechacreacion%type ,
    valorabono abono.valorabono%type,
    Tcliente_idcliente abono.cliente_idcliente%type,
    cocuenta abono.cuenta_codcuenta%type
)
as
--cocuenta number;
begin
--if(validarabono(valorabono, Tcliente_idcliente)=1) then
--if (buscarcliente(Tcliente_idcliente)=1) then
--select codcuenta into cocuenta from cuenta where cliente_idcliente = Tcliente_idcliente and estado = 'Activa';
insert into abono values(sec_abono.nextval, sysdate, valorabono, Tcliente_idcliente, cocuenta);
commit;
--end if;
--end if;
end;

FUNCTION buscarcliente(idcliente cuenta.cliente_idcliente%type) RETURN NUMBER is
cliente_id cuenta.cliente_idcliente%type;
begin
select idcliente into cliente_id from cliente where idcliente = cliente_id;
return 1;
EXCEPTION
when NO_DATA_FOUND THEN
RETURN 0;
END;

FUNCTION validarabono(Tvalorabono abono.valorabono%type, idcliente cuenta.cliente_idcliente%type) RETURN NUMBER is
deuda cuenta.valordeuda%type;
begin
select valordeuda into deuda from cuenta where cliente_idcliente = idcliente;
if(Tvalorabono > deuda) then
return 0;
else 
return 1;
end if;
end;
end;

--trigger para actualizar el total de los abonos y el valor de la deuda en una cuenta
create or replace TRIGGER tr_actualizarTotalAbonos
AFTER INSERT ON abono
FOR EACH ROW
DECLARE
BEGIN
UPDATE cuenta SET totalabonos=totalabonos + :new.valorabono where codcuenta=:new.cuenta_codcuenta;
UPDATE cuenta SET valordeuda=totalfacturas + saldoanterior - totalabonos where codcuenta=:new.cuenta_codcuenta;
END;

insert into abono values(sec_abono.nextval, sysdate, 2000, '4', '63');
insert into empleado values('admin', 'Juan', 'Camilo', 'Suarez', 'Toloza', 'Administrador', '3243454352', '3122435342', 'Mayales', '123');
commit;
select * from cuenta;
select extract(year from fechacreacion) año, extract (month from fechacreacion) mes, sum(totalfacturas)
from cuenta   group by (extract (year from fechacreacion), extract (month from fechacreacion)) order by año,mes asc;
 insert into cuenta values(sec_cuenta.nextval, '14/07/15', 500000, 'Activa', 500000, 500000, 500000, 4); 
 delete from empleado;
 