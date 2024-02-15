-- DROP SCHEMA public;

CREATE SCHEMA public AUTHORIZATION azure_pg_admin;

-- DROP SEQUENCE public.event_id_seq;

CREATE SEQUENCE public.event_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.ticket_id_seq;

CREATE SEQUENCE public.ticket_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;-- public."event" definition

-- Drop table

-- DROP TABLE public."event";

CREATE TABLE public."event" (
	id serial4 NOT NULL,
	event_name varchar(100) NULL,
	date_of_event date NULL,
	CONSTRAINT event_pkey PRIMARY KEY (id)
);


-- public.ticket definition

-- Drop table

-- DROP TABLE public.ticket;

CREATE TABLE public.ticket (
	id serial4 NOT NULL,
	event_id int4 NULL,
	user_email varchar(100) NULL,
	is_scanned bool NULL,
	ticketnumber varchar(100) NOT NULL,
	CONSTRAINT ticket_pkey PRIMARY KEY (id),
	CONSTRAINT ticket_event_id_fkey FOREIGN KEY (event_id) REFERENCES public."event"(id)
);