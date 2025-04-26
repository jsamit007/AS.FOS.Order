CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250426114444_InitialCommit') THEN
    CREATE TABLE "Cutomers" (
        "Id" uuid NOT NULL,
        CONSTRAINT "PK_Cutomers" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250426114444_InitialCommit') THEN
    CREATE TABLE "Orders" (
        "Id" uuid NOT NULL,
        "CustomerId" uuid NOT NULL,
        "RestaurantId" uuid NOT NULL,
        "DeliveryAddress_Street" text NOT NULL,
        "DeliveryAddress_City" text NOT NULL,
        "DeliveryAddress_State" text NOT NULL,
        "DeliveryAddress_ZipCode" text NOT NULL,
        "Status" text NOT NULL,
        CONSTRAINT "PK_Orders" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250426114444_InitialCommit') THEN
    CREATE TABLE "Resturants" (
        "RestaurantId" uuid NOT NULL,
        "IsOpen" boolean NOT NULL,
        CONSTRAINT "PK_Resturants" PRIMARY KEY ("RestaurantId")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250426114444_InitialCommit') THEN
    CREATE TABLE "OrderItem" (
        "Id" uuid NOT NULL,
        "ProductId" uuid NOT NULL,
        "Quantity" integer NOT NULL,
        "Price" numeric NOT NULL,
        "OrderEntityId" uuid,
        CONSTRAINT "PK_OrderItem" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_OrderItem_Orders_OrderEntityId" FOREIGN KEY ("OrderEntityId") REFERENCES "Orders" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250426114444_InitialCommit') THEN
    CREATE INDEX "IX_OrderItem_OrderEntityId" ON "OrderItem" ("OrderEntityId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250426114444_InitialCommit') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250426114444_InitialCommit', '9.0.4');
    END IF;
END $EF$;
COMMIT;

