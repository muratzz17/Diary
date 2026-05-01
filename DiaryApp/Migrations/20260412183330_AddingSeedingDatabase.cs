using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiaryApp.Migrations
{
    /// <inheritdoc />
    public partial class AddingSeedingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "DiaryEntryId", "Content", "Created", "Title" },
                values: new object[,]
                {
                    { 1, "Today I started my new diary app project. I'm excited to see how it turns out!", new DateTime(2026, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "My First Diary Entry" },
                    { 2, "I had a great day today! I went for a walk in the park and enjoyed the sunshine.", new DateTime(2026, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Sunny Day" },
                    { 3, "I had a tough day at work today. I'm glad to be home now and relax.", new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Tough Day" },
                    { 4, "I had a wonderful day with my family. We went to the beach and had a picnic.", new DateTime(2026, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Family Day" },
                    { 5, "I had a wonderful day with my family. We went to the beach and had a picnic.", new DateTime(2026, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Family Day" },
                    { 6, "I had a productive day today. I finished all my work and even had time to read a book.", new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Productive Day" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "DiaryEntryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "DiaryEntryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "DiaryEntryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "DiaryEntryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "DiaryEntryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "DiaryEntryId",
                keyValue: 6);
        }
    }
}
