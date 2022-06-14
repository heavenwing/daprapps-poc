create database mdm_product;

-- auto-generated definition
create table product
(
    id          uniqueidentifier                      not null
        constraint product_pk
            primary key,
    name        varchar(200)                          not null,
    is_exempted bit         default 0                 not null,
    create_by   varchar(50) default 'sys'             not null,
    create_time datetime,
    update_by   varchar(50) default 'sys'             not null,
    update_time datetime    default CURRENT_TIMESTAMP not null
);


create unique index product_id_uindex
    on product (id);

