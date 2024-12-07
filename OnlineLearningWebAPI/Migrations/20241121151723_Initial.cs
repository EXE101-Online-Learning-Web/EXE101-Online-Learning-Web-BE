using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineLearningWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseCategory",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseCa__23CAF1D8ACDABDB2", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "QuizType",
                columns: table => new
                {
                    quizTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__QuizType__6CB946D63325B49A", x => x.quizTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    roleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__CD98462A808B354B", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    accountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    passwordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    avatar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    isBan = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    isVip = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    dateSubscription = table.Column<DateOnly>(type: "date", nullable: true),
                    roleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Account__F267251EDDB46253", x => x.accountId);
                    table.ForeignKey(
                        name: "FK__Account__roleId__4D94879B",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "roleId");
                });

            migrationBuilder.CreateTable(
                name: "ActivityLog",
                columns: table => new
                {
                    activityLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountId = table.Column<int>(type: "int", nullable: false),
                    action = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    timestamp = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Activity__1025273EB10ED843", x => x.activityLogId);
                    table.ForeignKey(
                        name: "FK__ActivityL__accou__5EBF139D",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                });

            migrationBuilder.CreateTable(
                name: "Certificate",
                columns: table => new
                {
                    certificateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    courseId = table.Column<int>(type: "int", nullable: false),
                    accountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Certific__A15CBEAE9DB371B5", x => x.certificateId);
                    table.ForeignKey(
                        name: "FK__Certifica__accou__59063A47",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    courseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    teacherId = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createDate = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    categoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Course__2AA84FD10A5AAC84", x => x.courseId);
                    table.ForeignKey(
                        name: "FK__Course__category__4F7CD00D",
                        column: x => x.categoryId,
                        principalTable: "CourseCategory",
                        principalColumn: "categoryId");
                    table.ForeignKey(
                        name: "FK__Course__teacherI__4E88ABD4",
                        column: x => x.teacherId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrollment",
                columns: table => new
                {
                    courseEnrollmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountId = table.Column<int>(type: "int", nullable: false),
                    courseId = table.Column<int>(type: "int", nullable: false),
                    enrollmentDate = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    progressPercentage = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    isCompleted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseEn__3E39D9FCB3A7258F", x => x.courseEnrollmentId);
                    table.ForeignKey(
                        name: "FK__CourseEnr__accou__5CD6CB2B",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                    table.ForeignKey(
                        name: "FK__CourseEnr__cours__5DCAEF64",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "courseId");
                });

            migrationBuilder.CreateTable(
                name: "CourseTags",
                columns: table => new
                {
                    courseTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseId = table.Column<int>(type: "int", nullable: false),
                    tagName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseTa__E7E342A0200F6BB1", x => x.courseTagId);
                    table.ForeignKey(
                        name: "FK__CourseTag__cours__5BE2A6F2",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "courseId");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    feedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountId = table.Column<int>(type: "int", nullable: false),
                    courseId = table.Column<int>(type: "int", nullable: false),
                    feedbackText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Feedback__2613FD24A887532F", x => x.feedbackId);
                    table.ForeignKey(
                        name: "FK__Feedback__accoun__59FA5E80",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                    table.ForeignKey(
                        name: "FK__Feedback__course__5AEE82B9",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "courseId");
                });

            migrationBuilder.CreateTable(
                name: "FinalTest",
                columns: table => new
                {
                    finalTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseId = table.Column<int>(type: "int", nullable: false),
                    testName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    duration = table.Column<int>(type: "int", nullable: false),
                    generatedFromExamTests = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FinalTes__4069E5E8C41EC087", x => x.finalTestId);
                    table.ForeignKey(
                        name: "FK__FinalTest__cours__5629CD9C",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "courseId");
                });

            migrationBuilder.CreateTable(
                name: "MOOC",
                columns: table => new
                {
                    moocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseId = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createDate = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    isPublic = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MOOC__48B763A16B548D41", x => x.moocId);
                    table.ForeignKey(
                        name: "FK__MOOC__courseId__5070F446",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "courseId");
                });

            migrationBuilder.CreateTable(
                name: "ExamTest",
                columns: table => new
                {
                    examTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    moocId = table.Column<int>(type: "int", nullable: false),
                    testName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    duration = table.Column<int>(type: "int", nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ExamTest__DC7B3C15142788E6", x => x.examTestId);
                    table.ForeignKey(
                        name: "FK__ExamTest__create__52593CB8",
                        column: x => x.createdBy,
                        principalTable: "Account",
                        principalColumn: "accountId");
                    table.ForeignKey(
                        name: "FK__ExamTest__moocId__5165187F",
                        column: x => x.moocId,
                        principalTable: "MOOC",
                        principalColumn: "moocId");
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    quizId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    examTestId = table.Column<int>(type: "int", nullable: false),
                    quizName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    quizQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quizTypeId = table.Column<int>(type: "int", nullable: false),
                    maxScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Quiz__CFF54C3D65A7B54F", x => x.quizId);
                    table.ForeignKey(
                        name: "FK__Quiz__examTestId__534D60F1",
                        column: x => x.examTestId,
                        principalTable: "ExamTest",
                        principalColumn: "examTestId");
                    table.ForeignKey(
                        name: "FK__Quiz__quizTypeId__5441852A",
                        column: x => x.quizTypeId,
                        principalTable: "QuizType",
                        principalColumn: "quizTypeId");
                });

            migrationBuilder.CreateTable(
                name: "FinalTestQuiz",
                columns: table => new
                {
                    finalTestQuizId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    finalTestId = table.Column<int>(type: "int", nullable: false),
                    quizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FinalTes__55B42615F456CC99", x => x.finalTestQuizId);
                    table.ForeignKey(
                        name: "FK__FinalTest__final__571DF1D5",
                        column: x => x.finalTestId,
                        principalTable: "FinalTest",
                        principalColumn: "finalTestId");
                    table.ForeignKey(
                        name: "FK__FinalTest__quizI__5812160E",
                        column: x => x.quizId,
                        principalTable: "Quiz",
                        principalColumn: "quizId");
                });

            migrationBuilder.CreateTable(
                name: "QuizAnswer",
                columns: table => new
                {
                    quizAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quizId = table.Column<int>(type: "int", nullable: false),
                    answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isCorrect = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__QuizAnsw__92A9CCA7D3D2EAB4", x => x.quizAnswerId);
                    table.ForeignKey(
                        name: "FK__QuizAnswe__quizI__5535A963",
                        column: x => x.quizId,
                        principalTable: "Quiz",
                        principalColumn: "quizId");
                });

            migrationBuilder.InsertData(
                table: "CourseCategory",
                columns: new[] { "categoryId", "name" },
                values: new object[,]
                {
                    { 1, "Programming" },
                    { 2, "Design" },
                    { 3, "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "QuizType",
                columns: new[] { "quizTypeId", "typeName" },
                values: new object[,]
                {
                    { 1, "Multiple Choice" },
                    { 2, "True/False" },
                    { 3, "Short Answer" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "roleId", "name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Teacher" },
                    { 3, "Student" },
                    { 4, "Vip Student" }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "accountId", "avatar", "dateSubscription", "email", "fullName", "isBan", "isVip", "passwordHash", "roleId" },
                values: new object[,]
                {
                    { 1, "admin_avatar.png", new DateOnly(2024, 1, 1), "admin@gmail.com", "Admin User", false, true, "123456", 1 },
                    { 2, "jane_avatar.png", new DateOnly(2024, 1, 1), "jane.smith@gmail.com", "Jane Smith", false, false, "123456", 2 },
                    { 3, "john_avatar.png", new DateOnly(2024, 1, 1), "john.davis@gmail.com", "John Davis", true, false, "123456", 3 }
                });

            migrationBuilder.InsertData(
                table: "ActivityLog",
                columns: new[] { "activityLogId", "accountId", "action", "details", "timestamp" },
                values: new object[,]
                {
                    { 1, 3, "Logged In", "User logged into the system.", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, "Enrolled in Course", "User enrolled in C# for Beginners.", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, "Completed Quiz", "User completed C# Basics Quiz.", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Certificate",
                columns: new[] { "certificateId", "accountId", "courseId", "image" },
                values: new object[,]
                {
                    { 1, 3, 1, "certificate1.jpg" },
                    { 2, 3, 2, "certificate2.jpg" },
                    { 3, 3, 3, "certificate3.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "courseId", "categoryId", "courseTitle", "createDate", "description", "teacherId" },
                values: new object[,]
                {
                    { 1, 1, "C# for Beginners", new DateOnly(2024, 1, 1), "Learn the basics of C# programming.", 2 },
                    { 2, 2, "Graphic Design Basics", new DateOnly(2024, 1, 1), "Introduction to graphic design principles.", 2 },
                    { 3, 3, "Digital Marketing 101", new DateOnly(2024, 1, 1), "Learn the fundamentals of digital marketing.", 2 }
                });

            migrationBuilder.InsertData(
                table: "CourseEnrollment",
                columns: new[] { "courseEnrollmentId", "accountId", "courseId", "enrollmentDate", "isCompleted", "progressPercentage" },
                values: new object[,]
                {
                    { 1, 3, 1, new DateOnly(2024, 1, 1), false, 25 },
                    { 2, 3, 2, new DateOnly(2024, 1, 1), false, 50 },
                    { 3, 3, 3, new DateOnly(2024, 1, 1), false, 0 }
                });

            migrationBuilder.InsertData(
                table: "CourseTags",
                columns: new[] { "courseTagId", "courseId", "tagName" },
                values: new object[,]
                {
                    { 1, 1, "C#" },
                    { 2, 2, "Design" },
                    { 3, 3, "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "feedbackId", "accountId", "courseId", "feedbackText", "rating" },
                values: new object[,]
                {
                    { 1, 3, 1, "Great course!", 5 },
                    { 2, 3, 2, "Very useful.", 4 },
                    { 3, 3, 3, "Informative content.", 5 }
                });

            migrationBuilder.InsertData(
                table: "FinalTest",
                columns: new[] { "finalTestId", "courseId", "duration", "generatedFromExamTests", "testName" },
                values: new object[,]
                {
                    { 1, 1, 120, true, "Final Test C#" },
                    { 2, 2, 90, false, "Final Test Design" },
                    { 3, 3, 60, true, "Final Test Marketing" }
                });

            migrationBuilder.InsertData(
                table: "MOOC",
                columns: new[] { "moocId", "courseId", "createDate", "description", "isPublic" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2024, 1, 1), "MOOC for C# basics", true },
                    { 2, 2, new DateOnly(2024, 1, 1), "MOOC for design principles", true },
                    { 3, 3, new DateOnly(2024, 1, 1), "MOOC for marketing strategies", false }
                });

            migrationBuilder.InsertData(
                table: "ExamTest",
                columns: new[] { "examTestId", "createdBy", "duration", "moocId", "testName" },
                values: new object[,]
                {
                    { 1, 2, 60, 1, "Programming Test" },
                    { 2, 2, 45, 2, "Design Test" },
                    { 3, 2, 30, 3, "Marketing Test" }
                });

            migrationBuilder.InsertData(
                table: "Quiz",
                columns: new[] { "quizId", "examTestId", "maxScore", "quizName", "quizQuestion", "quizTypeId" },
                values: new object[,]
                {
                    { 1, 1, 10, "C# Basics", "What is a class in C#?", 1 },
                    { 2, 2, 15, "Design Principles", "Is design important?", 2 },
                    { 3, 3, 20, "Marketing Strategies", "Describe the 4Ps of marketing.", 3 }
                });

            migrationBuilder.InsertData(
                table: "FinalTestQuiz",
                columns: new[] { "finalTestQuizId", "finalTestId", "quizId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "QuizAnswer",
                columns: new[] { "quizAnswerId", "answer", "isCorrect", "quizId" },
                values: new object[,]
                {
                    { 1, "A class is a blueprint for objects.", true, 1 },
                    { 2, "A class is a type of variable.", false, 1 },
                    { 3, "Yes", true, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_roleId",
                table: "Account",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLog_accountId",
                table: "ActivityLog",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_accountId",
                table: "Certificate",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_categoryId",
                table: "Course",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_teacherId",
                table: "Course",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollment_accountId",
                table: "CourseEnrollment",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollment_courseId",
                table: "CourseEnrollment",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTags_courseId",
                table: "CourseTags",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTest_createdBy",
                table: "ExamTest",
                column: "createdBy");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTest_moocId",
                table: "ExamTest",
                column: "moocId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_accountId",
                table: "Feedback",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_courseId",
                table: "Feedback",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalTest_courseId",
                table: "FinalTest",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalTestQuiz_finalTestId",
                table: "FinalTestQuiz",
                column: "finalTestId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalTestQuiz_quizId",
                table: "FinalTestQuiz",
                column: "quizId");

            migrationBuilder.CreateIndex(
                name: "IX_MOOC_courseId",
                table: "MOOC",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_examTestId",
                table: "Quiz",
                column: "examTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_quizTypeId",
                table: "Quiz",
                column: "quizTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswer_quizId",
                table: "QuizAnswer",
                column: "quizId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLog");

            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "CourseEnrollment");

            migrationBuilder.DropTable(
                name: "CourseTags");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "FinalTestQuiz");

            migrationBuilder.DropTable(
                name: "QuizAnswer");

            migrationBuilder.DropTable(
                name: "FinalTest");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "ExamTest");

            migrationBuilder.DropTable(
                name: "QuizType");

            migrationBuilder.DropTable(
                name: "MOOC");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "CourseCategory");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
