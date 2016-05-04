using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ProposalPostgresProvider;

namespace ProposalPostgresProvider.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    [Migration("20160504023531_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("ProposalDomain.Model.ActivityType", b =>
                {
                    b.Property<int>("ActivityTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("ActivityTypeId");
                });

            modelBuilder.Entity("ProposalDomain.Model.Proposal", b =>
                {
                    b.Property<int>("ProposalId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ActivityTypeActivityTypeId");

                    b.Property<int>("CampaignId");

                    b.Property<DateTime>("Created");

                    b.Property<int>("CurrencyCode");

                    b.Property<string>("Description");

                    b.Property<int>("OwnerId");

                    b.Property<int>("ProgramId");

                    b.Property<int?>("ProposalStateStateId");

                    b.Property<int?>("ProposalTypeTypeId");

                    b.Property<string>("Title");

                    b.Property<DateTime>("Updated");

                    b.HasKey("ProposalId");
                });

            modelBuilder.Entity("ProposalDomain.Model.ProposalState", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("StateId");
                });

            modelBuilder.Entity("ProposalDomain.Model.ProposalType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("TypeId");
                });

            modelBuilder.Entity("ProposalDomain.Model.Proposal", b =>
                {
                    b.HasOne("ProposalDomain.Model.ActivityType")
                        .WithMany()
                        .HasForeignKey("ActivityTypeActivityTypeId");

                    b.HasOne("ProposalDomain.Model.ProposalState")
                        .WithMany()
                        .HasForeignKey("ProposalStateStateId");

                    b.HasOne("ProposalDomain.Model.ProposalType")
                        .WithMany()
                        .HasForeignKey("ProposalTypeTypeId");
                });
        }
    }
}
