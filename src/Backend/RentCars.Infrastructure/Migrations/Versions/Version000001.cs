using FluentMigrator;
using RentCars.Domain.Enums;

namespace RentCars.Infrastructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_USER, "Create table to save the car's information")]
    public class Version000001 : VersionBase
    {
        public override void Up()
        {
            CreateTable("Cars")
                .WithColumn("Model").AsString(40).NotNullable()
                .WithColumn("Brand").AsString(20).NotNullable()
                .WithColumn("Year").AsString(4).NotNullable()
                .WithColumn("License_Plate").AsString(7).NotNullable()
                .WithColumn("Status")
                    .AsInt32()
                    .NotNullable()
                    .WithDefaultValue((int)EnumCarStatus.Available)
                    .WithColumnDescription("Enum: 0-Available, 1-Rented, 2-Maintenance")
                .WithColumn("Air_conditioning").AsBoolean().NotNullable()
                .WithColumn("ABS").AsBoolean().NotNullable()
                .WithColumn("Automatic_transmission").AsBoolean().NotNullable()
                .WithColumn("Steering_type").AsInt32().NotNullable()
                .WithColumn("Num_passengers").AsInt32().NotNullable();
        }
    }
}
