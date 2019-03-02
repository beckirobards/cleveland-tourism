
-- Switch to the system (aka master) database
USE master;
GO

-- Delete CleTourism (IF EXISTS)
IF EXISTS(select * from sys.databases where name='CleTourism')
DROP DATABASE CleTourism;
GO

-- Create a new CleTourism
CREATE DATABASE CleTourism;
GO

-- Switch to the CleTourism Database
USE CleTourism;
GO

-- Begin a TRANSACTION that must complete with no errors
BEGIN TRANSACTION;

CREATE TABLE neighborhoods
(
	id			int				identity,
	name		varchar(30)		not null,

	constraint	pk_neighborhoods	primary key		(id)
);

CREATE TABLE categories
(
	id			int				identity,
	name		varchar(20)		not null,

	constraint		pk_categories	primary key		(id),
);

CREATE TABLE activities
(
	id				int				identity,
	name			varchar(50)		not null,
	neighborhood_id	int				not null,
	address_number	int				not null,
	street_name		varchar(30)		not null,
	address2		varchar(20),
	city			varchar(30)		not null,
	state			char(2)			not null,
	zip_code		varchar(9)		not null,
	website			varchar(100)	not null,
	phone			char(10)		not null,
	price_range		int				not null,
	description		varchar(500)	not null,
	avg_length		int,
	avg_rating		int				not null default(0),
	rating_count	int				not null default(0),
	image			varchar(200),
	sun_open		time,
	sun_close		time,
	mon_open		time,
	mon_close		time,
	tues_open		time,
	tues_close		time,
	wed_open		time,
	wed_close		time,
	thurs_open		time,
	thurs_close		time,
	fri_open		time,
	fri_close		time,
	sat_open		time,
	sat_close		time,

	constraint		pk_activities				primary key		(id),
	constraint		fk_activities_neighborhoods	foreign key		(neighborhood_id) references neighborhoods (id)
);


CREATE TABLE reviews
(
	id			int				identity,
	first_name	varchar(30)		not null,	
	last_name	varchar(30)		not null,
	activity_id	int				not null,
	rating		int				not null,
	review		varchar(500),

	constraint		pk_reviews					primary key		(id),
	constraint		fk_reviews_neighborhoods	foreign key		(activity_id) references activities (id)
);

CREATE TABLE activities_categories
(
	activity_id	int		not null,
	category_id	int		not null,

	constraint		pk_activities_categories			primary key		(activity_id, category_id),
	constraint		fk_activities_categories_activities	foreign key		(activity_id) references activities (id),
	constraint		fk_activities_categories_categories	foreign key		(category_id) references categories (id)
);

INSERT INTO neighborhoods(name) VALUES ('Ohio City');
INSERT INTO categories(name) VALUES ('Bar');
INSERT INTO activities(name,neighborhood_id,address_number,street_name,city,state,zip_code,
website,phone,price_range,description,avg_length,image,sun_open,sun_close,mon_open,mon_close,
tues_open,tues_close,wed_open,wed_close,thurs_open,thurs_close,fri_open,fri_close,sat_open,sat_close)
VALUES('Great Lakes Brewing Company',(SELECT id FROM neighborhoods WHERE name='Ohio City'),2516,
'Market Ave','Cleveland','OH','44113','https://www.greatlakesbrewing.com/','2167714404',2,'The first brewpub 
and microbrewery in the state of Ohio, Great Lakes Brewing has been noted as important to Cleveland''s local 
identity and as one of the initial forces behind the revival of the Ohio City neighborhood on the near West 
Side.',75,'https://www.greatlakesbrewing.com/sites/default/files/dortmunder-fixed_2.png','11:00:00','23:00:00',
'11:00:00','23:00:00','11:00:00','23:00:00','11:00:00','23:00:00','11:00:00','23:00:00','11:00:00','23:00:00',
'11:00:00','23:00:00');
INSERT INTO reviews(first_name,last_name,activity_id,rating,review) VALUES ('Leslie','Knope',(SELECT id FROM 
activities WHERE name='Great Lakes Brewing Company'),5,'10/10 would recommend');

COMMIT TRANSACTION;