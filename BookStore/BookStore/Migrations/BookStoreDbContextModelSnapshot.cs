﻿// <auto-generated />
using System;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStore.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    partial class BookStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookStore.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("9b0c1a73-265d-4a10-b3e8-45e385796a47"),
                            AccessFailedCount = 0,
                            CartId = 0,
                            ConcurrencyStamp = "6074a303-7ce2-4c63-9f78-465b430e3d70",
                            Email = "admin@admin.com",
                            EmailConfirmed = false,
                            IsAdmin = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@admin.com",
                            NormalizedUserName = "admin@admin.com",
                            PasswordHash = "ALzfytQBytl1WoYjZpX48ZeVn3ryI4tnS81EVa10wqTUxrPjKPIN7EYM+A56LYAgnA==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com"
                        });
                });

            modelBuilder.Entity("BookStore.Data.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasMaxLength(2050)
                        .HasColumnType("nvarchar(2050)");

                    b.Property<string>("ShortBiography")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Robert Jordan",
                            IsDeleted = false,
                            PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Robert_Jordan.jpg/330px-Robert_Jordan.jpg",
                            ShortBiography = "James Oliver Rigney Jr. (October 17, 1948 – September 16, 2007), better known by his pen name Robert Jordan, was an American author of epic fantasy. He is known best for his series The Wheel of Time (finished by Brandon Sanderson after Jordan's death) which comprises 14 books and a prequel novel. He is one of several writers to have written original Conan the Barbarian novels; his are considered by fans to be some of the best of the non-Robert E. Howard efforts. Jordan also published historical fiction using the pseudonym Reagan O'Neal, a western as Jackson O'Reilly, and dance criticism as Chang Lung. Jordan claimed to have ghostwritten an \"international thriller\" that is still believed to have been written by someone else."
                        },
                        new
                        {
                            Id = 2,
                            FullName = "J. R. R. Tolkien",
                            IsDeleted = false,
                            PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/J._R._R._Tolkien%2C_ca._1925.jpg/330px-J._R._R._Tolkien%2C_ca._1925.jpg",
                            ShortBiography = "John Ronald Reuel Tolkien CBE FRSL (/ˈruːl ˈtɒlkiːn/, ROOL TOL-keen;[a] 3 January 1892 – 2 September 1973) was an English writer and philologist. He was the author of the high fantasy works The Hobbit and The Lord of the Rings. nFrom 1925 to 1945, Tolkien was the Rawlinson and Bosworth Professor of Anglo-Saxon and a Fellow of Pembroke College, both at the University of Oxford. He then moved within the same university to become the Merton Professor of English Language and Literature and Fellow of Merton College, and held these positions from 1945 until his retirement in 1959. Tolkien was a close friend of C. S. Lewis, a co-member of the informal literary discussion group The Inklings. He was appointed a Commander of the Order of the British Empire by Queen Elizabeth II on 28 March 1972. After Tolkien's death, his son Christopher published a series of works based on his father's extensive notes and unpublished manuscripts, including The Silmarillion. These, together with The Hobbit and The Lord of the Rings, form a connected body of tales, poems, fictional histories, invented languages, and literary essays about a fantasy world called Arda and, within it, Middle-earth. Between 1951 and 1955, Tolkien applied the term legendarium to the larger part of these writings. While many other authors had published works of fantasy before Tolkien, the great success of The Hobbit and The Lord of the Rings led directly to a popular resurgence of the genre. This has caused him to be popularly identified as the \"father\" of modern fantasy literature—or, more precisely, of high fantasy."
                        },
                        new
                        {
                            Id = 3,
                            FullName = "J. K. Rowling",
                            IsDeleted = false,
                            PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5d/J._K._Rowling_2010.jpg/330px-J._K._Rowling_2010.jpg",
                            ShortBiography = "Joanne Rowling, born 31 July 1965, best known by her pen name J. K. Rowling, is a British author and philanthropist. She wrote Harry Potter, a seven-volume children's fantasy series published from 1997 to 2007. The series has sold over 600 million copies, been translated into 84 languages, and spawned a global media franchise including films and video games. The Casual Vacancy (2012) was her first novel for adults. She writes Cormoran Strike, an ongoing crime fiction series, under the alias Robert Galbraith."
                        },
                        new
                        {
                            Id = 4,
                            FullName = "Brandon Sanderson",
                            IsDeleted = false,
                            PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ef/Brandon_Sanderson_-_Lucca_Comics_%26_Games_2016.jpg/330px-Brandon_Sanderson_-_Lucca_Comics_%26_Games_2016.jpg",
                            ShortBiography = "Brandon Winn Sanderson (born December 19, 1975) is an American author of high fantasy and science fiction. He is best known for the Cosmere fictional universe, in which most of his fantasy novels, most notably the Mistborn series and The Stormlight Archive, are set. Outside of the Cosmere, he has written several young adult and juvenile series including The Reckoners, the Skyward series,[a] and the Alcatraz series. He is also known for finishing Robert Jordan's high fantasy series The Wheel of Time. Sanderson has created several graphic novel fantasy series, including White Sand and Dark One. He created Sanderson's Laws of Magic and popularized the idea of \"hard magic\" and \"soft magic\" systems. In 2008, Sanderson started a podcast with author Dan Wells and cartoonist Howard Tayler called Writing Excuses, involving topics about creating genre writing and webcomics. In 2016, the American media company DMG Entertainment licensed the movie rights to Sanderson's entire Cosmere universe, but the rights have since reverted back to Sanderson. Sanderson's March 2022 Kickstarter campaign became the most successful in history, finishing with 185,341 backers pledging $41,754,153."
                        });
                });

            modelBuilder.Entity("BookStore.Data.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasMaxLength(2050)
                        .HasColumnType("nvarchar(2050)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CartId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CategoryId = 1,
                            Description = "The Eye of the World is a high fantasy novel by American writer Robert Jordan, the first book of The Wheel of Time series. It was published by Tor Books and released on 15 January 1990. The unabridged audiobook is read by Michael Kramer and Kate Reading. Upon first publication, The Eye of the World consisted of one prologue and 53 chapters, with an additional prologue authored upon re-release. The book was a critical, and commercial success. Critics praised the tone, the themes, and the similarity to Lord of the Rings (although some criticized it for that). On 2 January 2002, The Eye of the World was re-released as two separate books aimed at a young adult market, with larger text and a handful of illustrations. These were From the Two Rivers and To the Blight. The former included an additional prologue entitled \"Ravens\", focusing on Egwene al'Vere. The American Library Association put The Eye of the World on its 2003 list of Popular Paperbacks for Young Adults. After the release of The Wheel of Time television series, The Eye of the World made the January 2022 The New York Times Best Seller list in the mass market category and was number one on the audio fiction list.",
                            IsDeleted = false,
                            PhotoUrl = "https://upload.wikimedia.org/wikipedia/en/0/00/WoT01_TheEyeOfTheWorld.jpg",
                            Price = 20m,
                            Title = "The Eye of the World"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            CategoryId = 1,
                            Description = "The Great Hunt is a fantasy novel by American author Robert Jordan, the second book of The Wheel of Time series. It was published by Tor Books and released on November 15, 1990. The Great Hunt consists of a prologue and 50 chapters. In 2004 The Great Hunt was re-released as two separate books, The Hunt Begins and New Threads in the Pattern. The story features young heroes Rand al'Thor, Mat Cauthon, and Perrin Aybara, who join Shienaren soldiers in a quest to retrieve the Horn of Valere. At the same time, Egwene al'Vere, Nynaeve al'Meara, and Elayne Trakand go to the White Tower in Tar Valon to learn Aes Sedai ways. Finally, an exotic army invades the western coast.",
                            IsDeleted = false,
                            PhotoUrl = "https://upload.wikimedia.org/wikipedia/en/4/4b/WoT02_TheGreatHunt.jpg",
                            Price = 25m,
                            Title = "The Great Hunt"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            CategoryId = 1,
                            Description = "Harry Potter and the Philosopher's Stone is a fantasy novel written by British author J. K. Rowling. The first novel in the Harry Potter series and Rowling's debut novel, it follows Harry Potter, a young wizard who discovers his magical heritage on his eleventh birthday, when he receives a letter of acceptance to Hogwarts School of Witchcraft and Wizardry. Harry makes close friends and a few enemies during his first year at the school and with the help of his friends, Ron Weasley and Hermione Granger, he faces an attempted comeback by the dark wizard Lord Voldemort, who killed Harry's parents, but failed to kill Harry when he was just 15 months old.",
                            IsDeleted = false,
                            PhotoUrl = "https://upload.wikimedia.org/wikipedia/en/6/6b/Harry_Potter_and_the_Philosopher%27s_Stone_Book_Cover.jpg",
                            Price = 15m,
                            Title = "Harry Potter and the Philosopher's Stone"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 4,
                            CategoryId = 1,
                            Description = "Mistborn: The Final Empire is set on the dystopian world of Scadrial, where ash constantly falls from the sky, all plants are brown, and supernatural mists cloak the landscape every night. One thousand years before the start of the novel, the prophesied Hero of Ages ascended to godhood at the Well of Ascension in order to repel the Deepness, a terror threatening the world whose true nature has since been lost to time. Though the Deepness was successfully repelled and mankind saved, the world was changed into its current form by the Hero, who took the title \"Lord Ruler\" and has ruled over the Final Empire for a thousand years as an immortal tyrant and god. Under his rule, society is stratified into the nobility, believed to be the descendants of the friends and allies who helped him achieve godhood, and the brutally oppressed peasantry descended from those who opposed him, known as skaa.",
                            IsDeleted = false,
                            PhotoUrl = "https://upload.wikimedia.org/wikipedia/en/4/44/Mistborn-cover.jpg",
                            Price = 30m,
                            Title = "Mistborn: The Final Empire"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 2,
                            CategoryId = 1,
                            Description = "The Fellowship of the Ring is the first of three volumes of the epic novel[2] The Lord of the Rings by the English author J. R. R. Tolkien. It is followed by The Two Towers and The Return of the King. The action takes place in the fictional universe of Middle-earth. The book was first published on 29 July 1954 in the United Kingdom. The volume consists of a foreword, in which the author discusses his writing of The Lord of the Rings, a prologue titled \"Concerning Hobbits, and other matters\", and the main narrative in Book I and Book II.",
                            IsDeleted = false,
                            PhotoUrl = "https://upload.wikimedia.org/wikipedia/en/8/8e/The_Fellowship_of_the_Ring_cover.gif",
                            Price = 50m,
                            Title = "The Fellowship of the Ring"
                        });
                });

            modelBuilder.Entity("BookStore.Data.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("BookStore.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Historical"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Western"
                        });
                });

            modelBuilder.Entity("BookStore.Data.Models.FavoriteAuthorUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("FavoriteAuthorsUsers");
                });

            modelBuilder.Entity("BookStore.Data.Models.FavoriteUserBook", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("FavoriteUsersBooks");
                });

            modelBuilder.Entity("BookStore.Data.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<Guid>("ReviewerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReviewerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StarRating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BookStore.Data.Models.UserBookBought", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("UsersBoughtBooks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BookStore.Data.Models.Book", b =>
                {
                    b.HasOne("BookStore.Data.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Data.Models.Cart", null)
                        .WithMany("Books")
                        .HasForeignKey("CartId");

                    b.HasOne("BookStore.Data.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BookStore.Data.Models.Cart", b =>
                {
                    b.HasOne("BookStore.Data.Models.ApplicationUser", "User")
                        .WithOne("Cart")
                        .HasForeignKey("BookStore.Data.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookStore.Data.Models.FavoriteAuthorUser", b =>
                {
                    b.HasOne("BookStore.Data.Models.Author", "Author")
                        .WithMany("FavoriteAuthorUsers")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookStore.Data.Models.FavoriteUserBook", b =>
                {
                    b.HasOne("BookStore.Data.Models.Book", "Book")
                        .WithMany("FavoriteUsersBook")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookStore.Data.Models.Review", b =>
                {
                    b.HasOne("BookStore.Data.Models.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Data.Models.ApplicationUser", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("BookStore.Data.Models.UserBookBought", b =>
                {
                    b.HasOne("BookStore.Data.Models.Book", "Book")
                        .WithMany("UserBoughtBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Data.Models.ApplicationUser", "User")
                        .WithMany("BoughtBooks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("BookStore.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("BookStore.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("BookStore.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookStore.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("BoughtBooks");

                    b.Navigation("Cart")
                        .IsRequired();

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("BookStore.Data.Models.Author", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("FavoriteAuthorUsers");
                });

            modelBuilder.Entity("BookStore.Data.Models.Book", b =>
                {
                    b.Navigation("FavoriteUsersBook");

                    b.Navigation("Reviews");

                    b.Navigation("UserBoughtBooks");
                });

            modelBuilder.Entity("BookStore.Data.Models.Cart", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
