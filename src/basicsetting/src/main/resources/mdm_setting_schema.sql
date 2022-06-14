create database mdm_setting;

-- auto-generated definition
create table inventory_limitation
(
    id          uniqueidentifier          not null
        constraint inventory_limitation_pk
            primary key,
    company_id  uniqueidentifier          not null,
    product_id  uniqueidentifier          not null,
    amount      bigint                    not null,
    create_by   varchar(50) default 'sys' not null,
    create_time datetime                  null,
    update_by   varchar(50) default 'sys' not null,
    update_time datetime                  NOT NULL DEFAULT CURRENT_TIMESTAMP,
    constraint companyandproductuk
        unique (company_id, product_id)
);

-- auto-generated definition
create table biz_entity
(
    id            uniqueidentifier                      not null
        constraint biz_entity_pk
            primary key,
    biz_entity_id uniqueidentifier                      not null,
    product_id    uniqueidentifier                      not null,
    create_by     varchar(50) default 'sys'             not null,
    create_time   datetime,
    update_by     varchar(50) default 'sys'             not null,
    update_time   datetime    default CURRENT_TIMESTAMP not null,
    constraint bizandproductuk
        unique (biz_entity_id, product_id)
);



