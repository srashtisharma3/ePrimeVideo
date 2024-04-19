
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (1, N'Drama', N'Drama Movie')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (2, N'Romantic', N'Romantic Movie')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (3, N'Action', N'Action')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 
GO
INSERT [dbo].[Movies] ([Id], [Name], [Summary], [Description], [Thumbnail], [Banner], [Duration], [Language], [VideoUrl], [ReleaseDate], [CategoryId], [IsActive]) VALUES (1, N'Mission Mangal', N'Running against the clock, IAF Squadron Leader Vijay Karnik created history with determination and his love for the country. A daredevil story of guts and glory....', N'Based on the true story of India''s finest scientists who rose above hardships and failures to make us the only country to reach Mars in its first attempt...', N'/images/mov-1.jpg', N'/images/mov-1-banner.webp', N'01:53:00', N'hindi', N'https://www.youtube.com/embed/BlCPq_558rE', CAST(N'2021-12-24T07:30:00.000' AS DateTime), 1, 1)
GO
INSERT [dbo].[Movies] ([Id], [Name], [Summary], [Description], [Thumbnail], [Banner], [Duration], [Language], [VideoUrl], [ReleaseDate], [CategoryId], [IsActive]) VALUES (2, N'Super 30', N'Based on the life of ace mathematician Anand Kumar, who trained 30 underprivileged students to crack one of the toughest entrance exams in India - IIT....', N'Based on the life of ace mathematician Anand Kumar, who trained 30 underprivileged students to crack one of the toughest entrance exams in India - IIT....', N'/images/mov-2.jpg', N'/images/mov-2-banner.webp', N'01:53:00', N'hindi', N'https://www.youtube.com/embed/BlCPq_558rE', CAST(N'2021-10-12T00:00:00.000' AS DateTime), 1, 1)
GO
INSERT [dbo].[Movies] ([Id], [Name], [Summary], [Description], [Thumbnail], [Banner], [Duration], [Language], [VideoUrl], [ReleaseDate], [CategoryId], [IsActive]) VALUES (3, N'MS Dhoni: The Untold Story', N'A tell-all tale about the life and times of Indian cricketer, Mahendra Singh Dhoni; mapping his journey; from a ticket collector to a celebrated cricketer....', N'A tell-all tale about the life and times of Indian cricketer, Mahendra Singh Dhoni; mapping his journey; from a ticket collector to a celebrated cricketer....', N'/images/mov-3.jpg', N'/images/mov-3-banner.webp', N'01:53:00', N'hindi', N'https://www.youtube.com/embed/BlCPq_558rE', CAST(N'2021-10-12T00:00:00.000' AS DateTime), 1, 1)
GO
INSERT [dbo].[Movies] ([Id], [Name], [Summary], [Description], [Thumbnail], [Banner], [Duration], [Language], [VideoUrl], [ReleaseDate], [CategoryId], [IsActive]) VALUES (4, N'Tanhaji', N'As Aurangzeb captures the Kondhana Fort, Tanhaji Malusare, Chhatrapati Shivaji Maharaj''s trusted military leader and braveheart, ventures out to win it back....', N'As Aurangzeb captures the Kondhana Fort, Tanhaji Malusare, Chhatrapati Shivaji Maharaj''s trusted military leader and braveheart, ventures out to win it back....', N'/images/mov-4.jpg', N'/images/mov-4-banner.webp', N'01:53:00', N'hindi', N'https://www.youtube.com/embed/BlCPq_558rE', CAST(N'2021-10-12T00:00:00.000' AS DateTime), 1, 1)
GO
INSERT [dbo].[Movies] ([Id], [Name], [Summary], [Description], [Thumbnail], [Banner], [Duration], [Language], [VideoUrl], [ReleaseDate], [CategoryId], [IsActive]) VALUES (11, N'Bhaag Milkha Bhaag', N'The film chronicles Milkha Singh aka ''The Flying Sikh''s,'' incredible struggle - from being an orphan to becoming one of India''s greatest athletes.', N'The film chronicles Milkha Singh aka ''The Flying Sikh''s,'' incredible struggle - from being an orphan to becoming one of India''s greatest athletes.', N'/images/mov-5.jpg', N'/images/movie-5-banner.webp', N'02:03:10', N'hindi', N'https://www.youtube.com/embed/xEJYzu23-uM', CAST(N'2021-12-14T13:00:00.000' AS DateTime), 1, 1)
GO
INSERT [dbo].[Movies] ([Id], [Name], [Summary], [Description], [Thumbnail], [Banner], [Duration], [Language], [VideoUrl], [ReleaseDate], [CategoryId], [IsActive]) VALUES (12, N'Test Movie', N'Test Movie', N'Test Movie', N'/images/mov-6.jpg', N'/images/mov-6-banner.webp', N'02:00:00', N'hindi', N'1234', CAST(N'2022-01-19T18:30:00.000' AS DateTime), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Movies] OFF

SET IDENTITY_INSERT [dbo].[Plans] ON 
GO
INSERT [dbo].[Plans] ([Id], [Name], [Price], [Currency]) VALUES (1, N'Free', CAST(0.00 AS Decimal(18, 2)), N'INR')
GO
INSERT [dbo].[Plans] ([Id], [Name], [Price], [Currency]) VALUES (2, N'Plus', CAST(499.00 AS Decimal(18, 2)), N'INR')
GO
INSERT [dbo].[Plans] ([Id], [Name], [Price], [Currency]) VALUES (3, N'Premium', CAST(699.00 AS Decimal(18, 2)), N'INR')
GO
SET IDENTITY_INSERT [dbo].[Plans] OFF
GO
SET IDENTITY_INSERT [dbo].[Subscriptions] ON 
GO
INSERT [dbo].[Subscriptions] ([Id], [UserId], [SubscribedOn], [ExpiryOn], [PlanId]) VALUES (1, 2, CAST(N'2021-12-29T14:05:25.1743593' AS DateTime2), CAST(N'2022-12-29T14:05:25.1964108' AS DateTime2), 3)
GO
SET IDENTITY_INSERT [dbo].[Subscriptions] OFF
GO

SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [PhoneNumber], [EmailConfirmed], [CreatedDate]) VALUES (1, N'Admin', N'admin@gmail.com', N'$2a$11$MNPDLeF1XdKCj4NZMy4QG.e.T0H7TB4C4ddNUwtFmyGDa8AvUmF4S', N'9876543210', 0, CAST(N'2021-12-21T23:45:12.853' AS DateTime))
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [PhoneNumber], [EmailConfirmed], [CreatedDate]) VALUES (2, N'User', N'user@gmail.com', N'$2a$11$At3RC6SrxYW9eDaSYGRWgO4liGDbEJ9OycSpfzSOVgGEfSgwNK3XS', N'9876543210', 0, CAST(N'2021-12-21T23:47:27.647' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Admin')
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'User')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO

INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (1, 1)
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (2, 2)