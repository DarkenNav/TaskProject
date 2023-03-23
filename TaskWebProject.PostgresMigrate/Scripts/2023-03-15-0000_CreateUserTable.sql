CREATE TABLE IF NOT exists  public."Users" (
	"Id" serial4 NOT NULL,
	"Name" varchar(50) NULL,
	"Surname" varchar(50) NOT NULL,
	"Phone" varchar(12) NULL,
	"Email" varchar(128) NULL,
	"CreatedDate" timestamptz NULL
);

CREATE TABLE IF NOT exists public."Tasks" (
	"Id" serial4 NOT NULL,
	"Subject" varchar(255) NULL,
	"Description" text NULL,
	"ContractorId" int4 NULL,
	"InitiatorId" int4 NULL,
	"CreatedDate" timestamptz NULL,
	"DeadlineDate" timestamptz NULL
);