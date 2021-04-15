﻿// <auto-generated />
using System;
using DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(DigikalaContext))]
    [Migration("20200730051942_MainMenu")]
    partial class MainMenu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Entites.Brand.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrption")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("EnTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FaTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ImgName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("DataLayer.Entites.Brand.BrandCategory", b =>
                {
                    b.Property<int>("BrandCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("BrandCategoryId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BrandCategories");
                });

            modelBuilder.Entity("DataLayer.Entites.CategoryData.Categores", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrption")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("EnTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FaTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ImgName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DataLayer.Entites.CategoryData.CategoryRating", b =>
                {
                    b.Property<int>("CategoryRatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("RatingAttributeId")
                        .HasColumnType("int");

                    b.HasKey("CategoryRatingId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RatingAttributeId");

                    b.ToTable("CategoryRatings");
                });

            modelBuilder.Entity("DataLayer.Entites.CategoryData.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdParent")
                        .HasColumnType("int");

                    b.Property<int>("IdSubCat")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdParent");

                    b.HasIndex("IdSubCat");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("DataLayer.Entites.MainMenu.MainMenu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("MenuTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.HasKey("MenuId");

                    b.HasIndex("ParentId");

                    b.ToTable("MainMenus");
                });

            modelBuilder.Entity("DataLayer.Entites.Product.Comment.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommentDisLike")
                        .HasColumnType("int");

                    b.Property<int>("CommentLike")
                        .HasColumnType("int");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(3000)")
                        .HasMaxLength(3000);

                    b.Property<string>("CommentTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasMaxLength(100);

                    b.Property<bool>("IsConfirm")
                        .HasColumnType("bit")
                        .HasMaxLength(100);

                    b.Property<string>("Negative")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("Positive")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DataLayer.Entites.Product.Comment.CommentLike", b =>
                {
                    b.Property<int>("CommentLikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<bool>("Type")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentLikeId");

                    b.HasIndex("CommentId");

                    b.ToTable("CommentLikes");
                });

            modelBuilder.Entity("DataLayer.Entites.Product.Comment.CommentRating", b =>
                {
                    b.Property<int>("CommentRatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("RatingAttributeId")
                        .HasColumnType("int");

                    b.Property<byte>("Value")
                        .HasColumnType("tinyint");

                    b.HasKey("CommentRatingId");

                    b.HasIndex("ProductId");

                    b.HasIndex("RatingAttributeId");

                    b.ToTable("CommentRatings");
                });

            modelBuilder.Entity("DataLayer.Entites.Product.Comment.UserCommentRating", b =>
                {
                    b.Property<int>("UserCommentRatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("RatingAttributeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<byte>("Value")
                        .HasColumnType("tinyint");

                    b.HasKey("UserCommentRatingId");

                    b.HasIndex("ProductId");

                    b.HasIndex("RatingAttributeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserComments");
                });

            modelBuilder.Entity("DataLayer.Entites.Product.FAQ.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnswerDisLike")
                        .HasColumnType("int");

                    b.Property<int>("AnswerLike")
                        .HasColumnType("int");

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsConfirm")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("DataLayer.Entites.Product.FAQ.AnswerLike", b =>
                {
                    b.Property<int>("AnswerLikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<bool>("Type")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AnswerLikeId");

                    b.HasIndex("AnswerId");

                    b.HasIndex("UserId");

                    b.ToTable("AnswerLikes");
                });

            modelBuilder.Entity("DataLayer.Entites.Product.FAQ.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnswerCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsConfirm")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNotifiAnswer")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("QuestionId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("DataLayer.Entites.Product.ProductImage", b =>
                {
                    b.Property<int>("ProductImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImgName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ProductImageId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("DataLayer.Entites.Product.ProductProperty", b =>
                {
                    b.Property<int>("ProductPropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyValueId")
                        .HasColumnType("int");

                    b.HasKey("ProductPropertyId");

                    b.HasIndex("ProductId");

                    b.HasIndex("PropertyValueId");

                    b.ToTable("ProductProperties");
                });

            modelBuilder.Entity("DataLayer.Entites.Product.ProductRaview", b =>
                {
                    b.Property<int>("ProductReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Negative")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Positive")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortReview")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.HasKey("ProductReviewId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductRaviews");
                });

            modelBuilder.Entity("DataLayer.Entites.Product.ProductReviewRating", b =>
                {
                    b.Property<int>("ProductReviewRatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("RatingAttributeId")
                        .HasColumnType("int");

                    b.Property<byte>("Value")
                        .HasColumnType("tinyint");

                    b.HasKey("ProductReviewRatingId");

                    b.HasIndex("ProductId");

                    b.HasIndex("RatingAttributeId");

                    b.ToTable("ProductReviewRatings");
                });

            modelBuilder.Entity("DataLayer.Entites.Product.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("FaTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("ImgName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataLayer.Entites.Product.RatingAttributs", b =>
                {
                    b.Property<int>("RatingAttributeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("RatingAttributeId");

                    b.ToTable("RatingAttributs");
                });

            modelBuilder.Entity("DataLayer.Entites.Proprty.PropertyValue", b =>
                {
                    b.Property<int>("PropertyValueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PropertyNameId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("WikiText")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.HasKey("PropertyValueId");

                    b.HasIndex("PropertyNameId");

                    b.ToTable("PropertyValues");
                });

            modelBuilder.Entity("DataLayer.Entites.Proprty.ProprtyGroup", b =>
                {
                    b.Property<int>("PropertyGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("WikiText")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.HasKey("PropertyGroupId");

                    b.ToTable("ProprtyGroups");
                });

            modelBuilder.Entity("DataLayer.Entites.Proprty.ProprtyName", b =>
                {
                    b.Property<int>("PropertyNameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("PropertyGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<bool>("UseSearch")
                        .HasColumnType("bit");

                    b.Property<string>("WikiText")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.HasKey("PropertyNameId");

                    b.HasIndex("PropertyGroupId");

                    b.ToTable("ProprtyNames");
                });

            modelBuilder.Entity("DataLayer.Entites.Slider", b =>
                {
                    b.Property<int>("SliderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrption")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ImgName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("sort")
                        .HasColumnType("int");

                    b.HasKey("SliderId");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("DataLayer.Entites.User.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataLayer.Entites.Brand.BrandCategory", b =>
                {
                    b.HasOne("DataLayer.Entites.Brand.Brand", "Brand")
                        .WithMany("BrandCategories")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataLayer.Entites.CategoryData.Categores", "Categores")
                        .WithMany("BrandCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entites.CategoryData.CategoryRating", b =>
                {
                    b.HasOne("DataLayer.Entites.CategoryData.Categores", "Categores")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataLayer.Entites.Product.RatingAttributs", "RatingTitle")
                        .WithMany("CategoryRatings")
                        .HasForeignKey("RatingAttributeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entites.CategoryData.SubCategory", b =>
                {
                    b.HasOne("DataLayer.Entites.CategoryData.Categores", "ParentCategory")
                        .WithMany("parenteCategory")
                        .HasForeignKey("IdParent")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataLayer.Entites.CategoryData.Categores", "SubCatores")
                        .WithMany("SubCategory")
                        .HasForeignKey("IdSubCat")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entites.MainMenu.MainMenu", b =>
                {
                    b.HasOne("DataLayer.Entites.MainMenu.MainMenu", null)
                        .WithMany("MainMenus")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("DataLayer.Entites.Product.Comment.Comment", b =>
                {
                    b.HasOne("DataLayer.Entites.Product.Products", "Products")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataLayer.Entites.User.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entites.Product.Comment.CommentLike", b =>
                {
                    b.HasOne("DataLayer.Entites.Product.Comment.Comment", "Comment")
                        .WithMany("Comments")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entites.Product.Comment.CommentRating", b =>
                {
                    b.HasOne("DataLayer.Entites.Product.Products", "product")
                        .WithMany("CommentRatings")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataLayer.Entites.Product.RatingAttributs", "RatingAttribute")
                        .WithMany("CommentRatings")
                        .HasForeignKey("RatingAttributeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entites.Product.Comment.UserCommentRating", b =>
                {
                    b.HasOne("DataLayer.Entites.Product.Products", "Products")
                        .WithMany("UserCommentRatings")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataLayer.Entites.Product.RatingAttributs", "RatingAttributs")
                        .WithMany("UserCommentRatings")
                        .HasForeignKey("RatingAttributeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataLayer.Entites.User.User", "User")
                        .WithMany("UserCommentRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entites.Product.FAQ.Answer", b =>
                {
                    b.HasOne("DataLayer.Entites.Product.FAQ.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataLayer.Entites.User.User", "User")
                        .WithMany("Answers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entites.Product.FAQ.AnswerLike", b =>
                {
                    b.HasOne("DataLayer.Entites.Product.FAQ.Answer", "Answer")
                        .WithMany("AnswerLikes")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataLayer.Entites.User.User", "User")
                        .WithMany("AnswerLikes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entites.Product.FAQ.Question", b =>
                {
                    b.HasOne("DataLayer.Entites.Product.Products", "Products")
                        .WithMany("Questions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataLayer.Entites.User.User", "User")
                        .WithMany("Questions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entites.Product.ProductImage", b =>
                {
                    b.HasOne("DataLayer.Entites.Product.Products", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entites.Product.ProductProperty", b =>
                {
                    b.HasOne("DataLayer.Entites.Product.Products", "Products")
                        .WithMany("ProductProperties")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataLayer.Entites.Proprty.PropertyValue", "PropertyValue")
                        .WithMany("ProductProperties")
                        .HasForeignKey("PropertyValueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entites.Product.ProductRaview", b =>
                {
                    b.HasOne("DataLayer.Entites.Product.Products", "Products")
                        .WithMany("ProductRaviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entites.Product.ProductReviewRating", b =>
                {
                    b.HasOne("DataLayer.Entites.Product.Products", "Products")
                        .WithMany("ProductReviewRatings")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataLayer.Entites.Product.RatingAttributs", "RatingAttribute")
                        .WithMany()
                        .HasForeignKey("RatingAttributeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entites.Product.Products", b =>
                {
                    b.HasOne("DataLayer.Entites.Brand.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataLayer.Entites.CategoryData.Categores", "Categores")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entites.Proprty.PropertyValue", b =>
                {
                    b.HasOne("DataLayer.Entites.Proprty.ProprtyName", "ProprtyName")
                        .WithMany("PropertyValues")
                        .HasForeignKey("PropertyNameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entites.Proprty.ProprtyName", b =>
                {
                    b.HasOne("DataLayer.Entites.Proprty.ProprtyGroup", "ProprtyGroup")
                        .WithMany("ProprtyNames")
                        .HasForeignKey("PropertyGroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
