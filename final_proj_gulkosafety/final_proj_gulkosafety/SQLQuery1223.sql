create table [user](
[email] nvarchar (150) NOT NULL,
[name] nvarchar (50) NOT NULL,
[phone] nvarchar (50),
[password] nvarchar (20) NOT NULL,
[user_type_num] smallint NOT NULL,
constraint fk_user foreign key(user_type_num) references user_type(user_type_num),
primary key(email)
)

drop table [order]

create table [user_type](
[user_type_num] smallint IDENTITY (1,1) NOT NULL,
[type_name] nvarchar (50) NOT NULL,
primary key(user_type_num)
)

create table [contact](
[id] nvarchar (50) NOT NULL,
[full_name] nvarchar (50) NOT NULL,
[phone] nvarchar (50),
[mail] nvarchar (150),
primary key(id)
)


create table [order](
[order_num] smallint IDENTITY (1,1) NOT NULL,
[bill_num] nvarchar (50) NOT NULL,
[date] date,
[price] float NOT NULL,
[contact_id] nvarchar (50) NOT NULL,
constraint fk_order foreign key(contact_id) references contact(id),
primary key(order_num)
)

create table [report](
[report_num] smallint IDENTITY (1,1) NOT NULL,
[date] date NOT NULL,
[time] time NOT NULL,
[grade] float,
[comment] nvarchar (300),
[project_num] smallint NOT NULL,
constraint fk_report foreign key(project_num) references project(project_num),
primary key(report_num)
)

create table[defect_in_report](
[report_num] smallint NOT NULL,
[defect_num] smallint NOT NULL,
[fix_date] date NOT NULL,
[fix_time] time NOT NULL,
[picture_link] nvarchar (250),
[fix_status] int,
[description] nvarchar (300),
primary key(report_num,defect_num),
constraint fk_report1 foreign key(report_num) references report(report_num),
constraint fk_defect1 foreign key(defect_num) references defect(defect_num)
 )