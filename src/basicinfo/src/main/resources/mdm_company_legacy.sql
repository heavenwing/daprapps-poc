create
    database mdm_company_legacy;


create table company
(
    id          uniqueidentifier                      not null,
    name        varchar(200)                          not null,
    create_by   varchar(50) default 'sys'             not null,
    create_time datetime,
    update_by   varchar(50) default 'sys'             not null,
    update_time datetime    default CURRENT_TIMESTAMP not null
);

create unique index company_id_uindex
    on company (id);

alter table company
    add constraint company_pk
        primary key (id);

insert into company(id, name, create_time)
values (newid(), 'company C', current_timestamp)