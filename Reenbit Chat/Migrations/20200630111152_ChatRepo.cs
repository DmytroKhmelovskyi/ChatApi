using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reenbit_Chat.Migrations
{
    public partial class ChatRepo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatUsers",
                columns: table => new
                {
                    ChatId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUsers", x => new { x.ChatId, x.UserId })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_ChatUsers_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(nullable: false),
                    ChatId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    MessageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageUsers", x => new { x.MessageId, x.UserId })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_MessageUsers_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "ChatName" },
                values: new object[,]
                {
                    { 1, "Chat_1" },
                    { 2, "Chat_2" },
                    { 3, "Chat_3" },
                    { 4, "Chat_4" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "User_1", "1111", "User" },
                    { 2, "User_2", "2222", "User" },
                    { 3, "User_3", "3333", "User" },
                    { 4, "User_4", "4444", "User" },
                    { 5, "User_5", "5555", "User" },
                    { 6, "User_6", "6666", "User" },
                    { 7, "User_7", "7777", "User" },
                    { 8, "User_8", "8888", "User" },
                    { 9, "User_9", "9999", "User" },
                    { 10, "User_10", "0000", "User" }
                });

            migrationBuilder.InsertData(
                table: "ChatUsers",
                columns: new[] { "ChatId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 4, 10 },
                    { 4, 9 },
                    { 4, 8 },
                    { 4, 7 },
                    { 4, 5 },
                    { 4, 4 },
                    { 4, 3 },
                    { 4, 2 },
                    { 4, 1 },
                    { 4, 6 },
                    { 3, 7 },
                    { 3, 6 },
                    { 3, 5 },
                    { 2, 4 },
                    { 2, 3 },
                    { 2, 2 },
                    { 2, 1 },
                    { 1, 2 },
                    { 3, 8 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatId", "DateTime", "SenderId", "Text" },
                values: new object[,]
                {
                    { 9, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "User_8 message_9" },
                    { 7, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "User_7 message_7" },
                    { 6, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "User_6 message_6" },
                    { 5, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "User_5 message_5" },
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "User_1 message_1" },
                    { 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "User_3 message_3" },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "User_2 message_2" },
                    { 8, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "User_1 message_8" },
                    { 10, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "User_9 message_10" },
                    { 4, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "User_4 message_4" },
                    { 11, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "User_10 message_11" }
                });

            migrationBuilder.InsertData(
                table: "MessageUsers",
                columns: new[] { "MessageId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 11, 8 },
                    { 11, 1 },
                    { 10, 10 },
                    { 10, 9 },
                    { 10, 8 },
                    { 10, 1 },
                    { 9, 10 },
                    { 9, 9 },
                    { 9, 8 },
                    { 9, 1 },
                    { 7, 7 },
                    { 7, 6 },
                    { 7, 5 },
                    { 6, 7 },
                    { 11, 9 },
                    { 6, 6 },
                    { 5, 7 },
                    { 5, 6 },
                    { 5, 5 },
                    { 4, 4 },
                    { 4, 3 },
                    { 3, 4 },
                    { 3, 3 },
                    { 2, 2 },
                    { 2, 1 },
                    { 8, 10 },
                    { 8, 9 },
                    { 8, 8 },
                    { 8, 1 },
                    { 1, 2 },
                    { 6, 5 },
                    { 11, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageUsers_UserId",
                table: "MessageUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatUsers");

            migrationBuilder.DropTable(
                name: "MessageUsers");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
