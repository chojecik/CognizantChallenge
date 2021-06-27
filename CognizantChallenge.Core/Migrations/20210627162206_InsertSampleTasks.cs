using Microsoft.EntityFrameworkCore.Migrations;

namespace CognizantChallenge.DAL.Migrations
{
    public partial class InsertSampleTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Tasks (TaskName, Description, InputParameter, OutputParameter) values ('Fibonacci sequence', 'Write a program that will produce n-th element of Fibonacci sequence. Assume that n is a given parameter of type string', '14', '377')");
            migrationBuilder.Sql("insert into Tasks (TaskName, Description, InputParameter, OutputParameter) values ('Factorial', 'Write a program that will produce n!. Assume that n is a given parameter of type string', '8', '40320')");
            migrationBuilder.Sql("insert into Tasks (TaskName, Description, InputParameter, OutputParameter) values ('Prime numbers', 'Write a program that will determine if the given number is a prime number. Assume that you are given a number to examine as a parameter of type string', '71171', 'True')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Tasks");
        }
    }
}
