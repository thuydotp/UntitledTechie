using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UntitledTechie.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 100, nullable: false),
                    AvatarImageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ImageId = table.Column<Guid>(nullable: false),
                    Caption = table.Column<string>(nullable: false),
                    NumberOfLikes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Account_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    PostId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Account_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubComment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    PostId = table.Column<Guid>(nullable: false),
                    CommentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubComment_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubComment_Account_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AvatarImageId", "Username" },
                values: new object[] { new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), new Guid("ed28c9f4-05ae-4930-bd15-30dc808438e5"), "TechieAdmin" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AvatarImageId", "Username" },
                values: new object[] { new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), new Guid("ed28c9f4-05ae-4930-bd15-30dc808438e5"), "TechieBot" });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Caption", "CreatedDate", "CreatorId", "ImageId", "ModifiedDate", "NumberOfLikes" },
                values: new object[,]
                {
                    { new Guid("80595434-108f-4afb-888c-c2fad733781c"), "This is the 1 post", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(5013), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), new Guid("6e1bda32-25e5-4a9c-9837-f4b3aa6a970f"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(5030), 1 },
                    { new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1"), "This is the 3 post", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(5051), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), new Guid("6e1bda32-25e5-4a9c-9837-f4b3aa6a970f"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(5052), 3 },
                    { new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d"), "This is the 0 post", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(4321), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), new Guid("6e1bda32-25e5-4a9c-9837-f4b3aa6a970f"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(4635), 0 },
                    { new Guid("a602c4aa-5876-4143-b47e-7635216a6270"), "This is the 2 post", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(5045), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), new Guid("6e1bda32-25e5-4a9c-9837-f4b3aa6a970f"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(5046), 2 },
                    { new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1"), "This is the 4 post", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(5056), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), new Guid("6e1bda32-25e5-4a9c-9837-f4b3aa6a970f"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(5057), 4 }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "CreatedDate", "CreatorId", "Description", "ModifiedDate", "PostId" },
                values: new object[,]
                {
                    { new Guid("5bde520c-70c0-4f5a-8008-b3e9f8bbc64b"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9522), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9522), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("b99006ce-f829-42fd-9033-74e79589c2ed"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9649), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9650), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("67566eac-5bf4-4150-bbd1-061bedd71861"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9643), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9644), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("33fca608-7598-45ea-9f6a-0d50b1b72fde"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9618), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9619), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("3369be5b-88bd-42ef-bdba-fef69872c1c0"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9610), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9611), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("a6fdc2a2-dd09-4f13-849d-4cdc307861b7"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9605), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9606), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("cc5cebbf-7313-4392-bd57-173c0c7d3194"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9598), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9599), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("63896fde-8755-4b73-9995-7589aebc1c7f"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9516), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9517), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("1aaa8c22-d076-4318-b836-0a09b9014199"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9501), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9502), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("731d905c-f6a3-48c5-8a98-50630ee9215f"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9493), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9495), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("78def8f4-5406-4a3a-a135-bd015ea6a80b"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9403), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9409), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("74c4774c-a40c-4701-9748-d0efae04e71d"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9638), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9639), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("de54a5ed-8529-4413-b506-22833bc56f78"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9633), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9634), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("07de691d-2e60-4e40-bf55-f07682147dc5"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9628), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9629), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("3384c688-b25b-4e10-8dac-dfa38d4ff4f5"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9623), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9624), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("cadaae7e-c7ea-478f-be31-a534d87d51c2"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9593), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9594), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("1d1f102e-ace6-465b-aadc-226bfa5ad359"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9535), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9536), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("860ee2c8-b583-4abc-8ee3-5e9fba2b65c2"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9530), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9531), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("67304698-5bf9-441a-9909-70f06c2642b5"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9654), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9655), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("518414b4-97a5-494a-aa1a-25bad86f9a47"), new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9662), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 comment", new DateTime(2020, 9, 15, 10, 31, 18, 123, DateTimeKind.Utc).AddTicks(9663), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") }
                });

            migrationBuilder.InsertData(
                table: "SubComment",
                columns: new[] { "Id", "CommentId", "CreatedDate", "CreatorId", "Description", "ModifiedDate", "PostId" },
                values: new object[,]
                {
                    { new Guid("5e93830c-db86-4c77-b058-8c0d04108933"), new Guid("5bde520c-70c0-4f5a-8008-b3e9f8bbc64b"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4199), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4200), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("fe74fd9e-382b-4252-bf74-61944e8c8571"), new Guid("3369be5b-88bd-42ef-bdba-fef69872c1c0"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4415), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4416), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("d8335c2c-9fe7-4a35-b1bf-39ccfbe8a712"), new Guid("3369be5b-88bd-42ef-bdba-fef69872c1c0"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4410), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4411), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("9395cce8-dd5b-46b7-b620-8d02d1c6d080"), new Guid("3369be5b-88bd-42ef-bdba-fef69872c1c0"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4404), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4405), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("5e672dac-9590-4fa4-9204-0b93ae8766bf"), new Guid("a6fdc2a2-dd09-4f13-849d-4cdc307861b7"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4361), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4362), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("6999137c-7d7f-4d37-8fe3-45ca94005d16"), new Guid("a6fdc2a2-dd09-4f13-849d-4cdc307861b7"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4356), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4357), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("863fb08c-3c7b-438e-bf9d-2ed1b66abd89"), new Guid("a6fdc2a2-dd09-4f13-849d-4cdc307861b7"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4351), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4352), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("ea0d087a-9084-4b5a-a748-94c5244453fb"), new Guid("a6fdc2a2-dd09-4f13-849d-4cdc307861b7"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4343), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4344), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("e4e18fe9-e5f6-4d08-9c68-ebf5e1eb418f"), new Guid("a6fdc2a2-dd09-4f13-849d-4cdc307861b7"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4338), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4339), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("8059fa67-1849-4db9-8779-a1c98f4cce6b"), new Guid("cc5cebbf-7313-4392-bd57-173c0c7d3194"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4333), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4334), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("b863509f-6e53-4a64-a2b5-80904dba852a"), new Guid("cc5cebbf-7313-4392-bd57-173c0c7d3194"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4328), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4329), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("b1164342-1913-4fab-b79a-40a3f036228f"), new Guid("cc5cebbf-7313-4392-bd57-173c0c7d3194"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4323), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4324), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("e79e3c60-86ae-44c8-b6dd-bbbe38a8461b"), new Guid("cc5cebbf-7313-4392-bd57-173c0c7d3194"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4317), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4318), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("317b8680-cfc4-4150-acdc-2dd78ad5a9e1"), new Guid("cc5cebbf-7313-4392-bd57-173c0c7d3194"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4312), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4313), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("37e629e7-1787-4e82-8d91-995b09e6f5bf"), new Guid("63896fde-8755-4b73-9995-7589aebc1c7f"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4194), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4195), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("a53ca82d-8689-488a-8af3-1b2dd61110ca"), new Guid("63896fde-8755-4b73-9995-7589aebc1c7f"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4189), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4190), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("cc20f6d5-76ad-4b32-a39b-928f00856ea2"), new Guid("63896fde-8755-4b73-9995-7589aebc1c7f"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4184), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4185), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("bc9292c6-bfdf-4cd0-8f01-1dea26dd0391"), new Guid("63896fde-8755-4b73-9995-7589aebc1c7f"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4177), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4178), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("3295676c-5e7d-44cc-856d-92601b159fd5"), new Guid("63896fde-8755-4b73-9995-7589aebc1c7f"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4172), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4173), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("d16afaf3-c46f-4b13-9ecc-e58b69b2665a"), new Guid("1aaa8c22-d076-4318-b836-0a09b9014199"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4115), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4116), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("22135157-51e7-4c3a-8086-ab28db98d371"), new Guid("1aaa8c22-d076-4318-b836-0a09b9014199"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4110), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4111), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("9617a830-beac-42ef-bcdc-8108a4cf24dc"), new Guid("1aaa8c22-d076-4318-b836-0a09b9014199"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4105), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4106), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("c001dc46-af45-43fc-9709-2949bb32e9b7"), new Guid("3369be5b-88bd-42ef-bdba-fef69872c1c0"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4420), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4421), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("65eb6171-234c-4bd4-8912-febd66401bfe"), new Guid("1aaa8c22-d076-4318-b836-0a09b9014199"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4099), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4100), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("270bce07-e18b-4f11-875d-3dadad45dce8"), new Guid("3369be5b-88bd-42ef-bdba-fef69872c1c0"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4425), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4426), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("3b43da3c-5945-4972-aff2-d4493ad9a761"), new Guid("33fca608-7598-45ea-9f6a-0d50b1b72fde"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4438), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4439), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("c4e6af88-a84c-4b6f-9bc6-8a94f818d34f"), new Guid("518414b4-97a5-494a-aa1a-25bad86f9a47"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4699), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4700), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("f948bf44-a075-4ff0-aada-88514e82dc1d"), new Guid("518414b4-97a5-494a-aa1a-25bad86f9a47"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4694), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4695), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("5714b4cd-815d-4cac-aaef-36f58c4e338f"), new Guid("518414b4-97a5-494a-aa1a-25bad86f9a47"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4689), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4690), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("f3202f4d-a00c-4da1-b362-d286464a13da"), new Guid("67304698-5bf9-441a-9909-70f06c2642b5"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4682), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4682), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("1ec8b623-b84b-42a2-a195-0fac9f3f0e9d"), new Guid("67304698-5bf9-441a-9909-70f06c2642b5"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4676), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4677), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("32fa1a3f-ff8a-4263-ad7c-19fb03795562"), new Guid("67304698-5bf9-441a-9909-70f06c2642b5"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4671), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4672), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("c2c27ab7-b96f-4218-8eb1-72517b81560c"), new Guid("67304698-5bf9-441a-9909-70f06c2642b5"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4666), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4667), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("9a952fb9-264e-419c-a76a-44ab1ce2f03c"), new Guid("67304698-5bf9-441a-9909-70f06c2642b5"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4661), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4662), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("95ab2119-0aa0-458c-9218-b2427b9e4033"), new Guid("b99006ce-f829-42fd-9033-74e79589c2ed"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4656), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4657), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("e10bea97-7266-42da-8446-e6ea4ee50474"), new Guid("b99006ce-f829-42fd-9033-74e79589c2ed"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4651), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4652), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("52ae8955-e676-4070-aaa2-4ec274e1cc57"), new Guid("b99006ce-f829-42fd-9033-74e79589c2ed"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4646), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4647), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("493661bf-b719-420e-b5e1-4534de3191d0"), new Guid("b99006ce-f829-42fd-9033-74e79589c2ed"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4639), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4640), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("45087fcc-d863-40c8-9e22-1af5f448a6e4"), new Guid("b99006ce-f829-42fd-9033-74e79589c2ed"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4634), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4635), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("12c3b6c3-6c16-4390-a406-afba2cf50a5a"), new Guid("67566eac-5bf4-4150-bbd1-061bedd71861"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4591), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4592), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("cec136ed-4173-4f25-b067-11de81e76775"), new Guid("67566eac-5bf4-4150-bbd1-061bedd71861"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4586), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4587), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("a34b20d1-2b6a-4e1e-af43-a5b360ebef2c"), new Guid("67566eac-5bf4-4150-bbd1-061bedd71861"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4581), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4582), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("1a49f628-0b6b-4aee-b958-ad7b2f8c38c8"), new Guid("67566eac-5bf4-4150-bbd1-061bedd71861"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4576), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4577), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("2a190bdf-6b33-4e40-91ef-c6a819738d1c"), new Guid("67566eac-5bf4-4150-bbd1-061bedd71861"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4571), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4572), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("4c1d14c5-4e32-4847-ab10-50fb445b1c86"), new Guid("33fca608-7598-45ea-9f6a-0d50b1b72fde"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4453), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4454), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("3d9f4228-25c9-4dd6-82e9-401400c4a7d3"), new Guid("33fca608-7598-45ea-9f6a-0d50b1b72fde"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4448), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4449), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("e5af60f1-6d80-4fc3-888e-732f151dc453"), new Guid("33fca608-7598-45ea-9f6a-0d50b1b72fde"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4443), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4444), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("4340c389-8b11-45a9-86ae-1c1a8833f69d"), new Guid("33fca608-7598-45ea-9f6a-0d50b1b72fde"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4433), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4434), new Guid("a602c4aa-5876-4143-b47e-7635216a6270") },
                    { new Guid("68fa93e2-9bd4-4eed-a85e-5d76211da3a6"), new Guid("1aaa8c22-d076-4318-b836-0a09b9014199"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4094), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4095), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("dedea96d-f74d-4bee-8fa1-fbad4fb4bd41"), new Guid("731d905c-f6a3-48c5-8a98-50630ee9215f"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4089), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4090), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("eac233e9-b66e-4214-9d1f-a5cd7174b902"), new Guid("731d905c-f6a3-48c5-8a98-50630ee9215f"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4082), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4083), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("d6f8c573-5a6b-42be-b07e-0467b834458a"), new Guid("3384c688-b25b-4e10-8dac-dfa38d4ff4f5"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4464), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4465), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("0b823702-be66-4660-8433-b6c7a749c3f4"), new Guid("3384c688-b25b-4e10-8dac-dfa38d4ff4f5"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4459), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4460), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("0accc70d-8b65-4331-bd6c-3d32600bb813"), new Guid("cadaae7e-c7ea-478f-be31-a534d87d51c2"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4307), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4307), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("a83aecf0-c5f0-4829-b707-a5b82e504d5a"), new Guid("cadaae7e-c7ea-478f-be31-a534d87d51c2"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4299), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4300), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("f240acac-5e52-47d2-8622-990d39fe0ef4"), new Guid("cadaae7e-c7ea-478f-be31-a534d87d51c2"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4293), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4294), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("e1721426-ab29-49d4-8bf6-bb90a11b3a58"), new Guid("cadaae7e-c7ea-478f-be31-a534d87d51c2"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4288), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4289), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("5094fe7c-4dfd-4c9d-b553-51c75288b94b"), new Guid("cadaae7e-c7ea-478f-be31-a534d87d51c2"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4283), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4284), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("81888ea6-fc55-4a25-9aca-fe8d46f755a2"), new Guid("1d1f102e-ace6-465b-aadc-226bfa5ad359"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4278), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4279), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("02e3de9b-56ad-4112-acc2-86e40e5e536f"), new Guid("1d1f102e-ace6-465b-aadc-226bfa5ad359"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4273), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4274), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("015b8960-34b5-40bf-a888-112ee36b42aa"), new Guid("1d1f102e-ace6-465b-aadc-226bfa5ad359"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4266), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4267), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("712c7f82-c2e8-4e73-9ccc-81c2ccd352e4"), new Guid("1d1f102e-ace6-465b-aadc-226bfa5ad359"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4261), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4262), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("23491524-b57f-4f5a-810b-655980e5a248"), new Guid("1d1f102e-ace6-465b-aadc-226bfa5ad359"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4254), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4254), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("f4a05a13-7f04-4653-a2c7-e93079fedd53"), new Guid("860ee2c8-b583-4abc-8ee3-5e9fba2b65c2"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4248), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4249), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("b1cc4962-7b09-4a50-835f-d1ee01dac604"), new Guid("860ee2c8-b583-4abc-8ee3-5e9fba2b65c2"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4243), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4244), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("3351793c-c25f-4386-a5de-c4b5e6d32a49"), new Guid("860ee2c8-b583-4abc-8ee3-5e9fba2b65c2"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4238), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4239), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("9da705a5-a30a-4962-af22-6453f01b043f"), new Guid("860ee2c8-b583-4abc-8ee3-5e9fba2b65c2"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4233), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4234), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("24193aaa-8024-488e-80b5-6909245c6837"), new Guid("860ee2c8-b583-4abc-8ee3-5e9fba2b65c2"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4228), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4229), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("75b545da-932b-4ec4-a914-193059fc9d71"), new Guid("5bde520c-70c0-4f5a-8008-b3e9f8bbc64b"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4222), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4223), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("e46ccad3-556c-48ee-8034-4fb18f428ed4"), new Guid("5bde520c-70c0-4f5a-8008-b3e9f8bbc64b"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4217), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4218), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("0990ad2c-16e5-46b0-8b6b-2a95269eaa71"), new Guid("5bde520c-70c0-4f5a-8008-b3e9f8bbc64b"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4209), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4210), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("b96ae5b9-5ed4-4adf-91af-58c621dd4a1e"), new Guid("5bde520c-70c0-4f5a-8008-b3e9f8bbc64b"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4204), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4205), new Guid("80595434-108f-4afb-888c-c2fad733781c") },
                    { new Guid("ecfcade3-ce51-4aa9-ac5b-7bb740762c52"), new Guid("3384c688-b25b-4e10-8dac-dfa38d4ff4f5"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4469), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4470), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("84021be6-ab2c-46f7-903b-e9c8b1b1c725"), new Guid("3384c688-b25b-4e10-8dac-dfa38d4ff4f5"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4477), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4478), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("9021972f-f5b2-493a-913c-e539aecbf40a"), new Guid("3384c688-b25b-4e10-8dac-dfa38d4ff4f5"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4482), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4483), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("5a6a0ac0-ed1f-4d3d-aa39-9b1424e29ba2"), new Guid("07de691d-2e60-4e40-bf55-f07682147dc5"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4489), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4490), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("f838a45d-8ae3-4bb5-8227-40fe9714b2fc"), new Guid("731d905c-f6a3-48c5-8a98-50630ee9215f"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4077), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4078), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("097fbcc3-6087-4772-acfa-36da5c8fe37e"), new Guid("731d905c-f6a3-48c5-8a98-50630ee9215f"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4064), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4065), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("f2802af7-9676-43c1-b46f-67614e15bee9"), new Guid("731d905c-f6a3-48c5-8a98-50630ee9215f"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4059), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4060), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("c6ed8364-4418-4737-9c63-3bfe84abfcd0"), new Guid("78def8f4-5406-4a3a-a135-bd015ea6a80b"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4050), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4051), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("062bf1d8-ad6b-4cc8-be32-922afb340342"), new Guid("78def8f4-5406-4a3a-a135-bd015ea6a80b"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4045), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4046), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("5c003b7f-ea5b-4e78-ac17-b98b88b7eb85"), new Guid("78def8f4-5406-4a3a-a135-bd015ea6a80b"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4039), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4040), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("a84b17a0-7852-4374-a103-d38e44fa41ba"), new Guid("78def8f4-5406-4a3a-a135-bd015ea6a80b"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4031), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4032), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("e2e7b5a2-80f0-495a-ac88-e96ad53be03c"), new Guid("78def8f4-5406-4a3a-a135-bd015ea6a80b"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(3946), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(3953), new Guid("33a52bc9-a469-4640-a3ec-7905e30ab82d") },
                    { new Guid("0130acf8-68a1-4144-9074-5783cc6e4326"), new Guid("74c4774c-a40c-4701-9748-d0efae04e71d"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4566), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4567), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("30555b96-9a6d-4d72-961b-dcaf26c9d412"), new Guid("74c4774c-a40c-4701-9748-d0efae04e71d"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4558), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4559), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("e99191e0-b6a9-4370-9688-69b5829dd618"), new Guid("518414b4-97a5-494a-aa1a-25bad86f9a47"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4704), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4705), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") },
                    { new Guid("8b61ec8a-7c90-4ce3-bcf2-35f7fc73ad09"), new Guid("74c4774c-a40c-4701-9748-d0efae04e71d"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4553), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4554), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("2e005342-4c2f-445b-bfac-b62279bb69f2"), new Guid("74c4774c-a40c-4701-9748-d0efae04e71d"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4543), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4544), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("2279c50b-2b03-43a6-80f4-86410adb41b3"), new Guid("de54a5ed-8529-4413-b506-22833bc56f78"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4538), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4539), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("b4c746a8-540d-475f-8e1f-1acf51f4e9e3"), new Guid("de54a5ed-8529-4413-b506-22833bc56f78"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4533), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4534), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("2cec82dd-3df2-4d9f-8ee6-18c7a15a338c"), new Guid("de54a5ed-8529-4413-b506-22833bc56f78"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4528), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4529), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("8556b894-5fdb-4f6a-81d3-f7e0fb1b4a6e"), new Guid("de54a5ed-8529-4413-b506-22833bc56f78"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4523), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4524), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("07118b27-ae73-4012-8cc1-9193fbbc3511"), new Guid("de54a5ed-8529-4413-b506-22833bc56f78"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4515), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 0 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4516), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("fa27833f-afef-45ab-9e5a-ea0357d82a95"), new Guid("07de691d-2e60-4e40-bf55-f07682147dc5"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4510), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4511), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("84ce0590-adf6-4123-9d39-6cd40b574b06"), new Guid("07de691d-2e60-4e40-bf55-f07682147dc5"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4505), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 3 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4506), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("159ce869-9113-4fb8-937b-e68e9b7b868b"), new Guid("07de691d-2e60-4e40-bf55-f07682147dc5"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4499), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 2 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4500), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("9c20b425-4457-4d79-b6d4-871f6c10beea"), new Guid("07de691d-2e60-4e40-bf55-f07682147dc5"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4494), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4495), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("b7fca1b3-ae71-4359-8770-4cecb469d5d1"), new Guid("74c4774c-a40c-4701-9748-d0efae04e71d"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4548), new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9"), "This is the 1 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4549), new Guid("e8ffcf5c-44fc-475f-80f9-694950ba65f1") },
                    { new Guid("e6b1d7bc-6921-4314-88ff-e80042c8e0a3"), new Guid("518414b4-97a5-494a-aa1a-25bad86f9a47"), new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4709), new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d"), "This is the 4 sub-comment", new DateTime(2020, 9, 15, 10, 31, 18, 124, DateTimeKind.Utc).AddTicks(4710), new Guid("8c976373-0f5f-4688-a6e4-14741b57d6e1") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CreatorId",
                table: "Comment",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CreatorId",
                table: "Post",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubComment_CommentId",
                table: "SubComment",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubComment_CreatorId",
                table: "SubComment",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubComment");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
