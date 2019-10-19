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

ALTER TABLE producto ADD CHECK ( costo > 0 );

ALTER TABLE producto ADD CHECK ( preciocompra > 0 );

ALTER TABLE producto ADD CHECK ( cantidadbodega > 0 );

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
--------------------------------------------------------------------------

