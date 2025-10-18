CREATE DATABASE DatingApp;
GO
USE [Dating App];
GO

-- ===========================
-- USERS (Tài khoản đăng nhập)
-- ===========================
CREATE TABLE Users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    email VARCHAR(100) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    phone VARCHAR(20),
    is_vip BIT DEFAULT 0,
    created_at DATETIME DEFAULT GETDATE()
);

-- ===========================
-- USER_PROFILE (Thông tin cá nhân)
-- ===========================
CREATE TABLE UserProfile (
    profile_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL FOREIGN KEY REFERENCES Users(user_id) ON DELETE CASCADE,
    name NVARCHAR(100),
    gender VARCHAR(10) CHECK (gender IN ('Male', 'Female', 'Other')),
    birthdate DATE,
    bio NVARCHAR(500),
    location NVARCHAR(255),
    avatar_url NVARCHAR(255),
    hobbies NVARCHAR(255),
    job NVARCHAR(100),
    education NVARCHAR(100)
);

-- ===========================
-- MATCHES (Ghép đôi)
-- ===========================
CREATE TABLE Matches (
    match_id INT IDENTITY(1,1) PRIMARY KEY,
    user1_id INT FOREIGN KEY REFERENCES Users(user_id),
    user2_id INT FOREIGN KEY REFERENCES Users(user_id),
    matched_at DATETIME DEFAULT GETDATE(),
);

-- ===========================
-- CHAT_MESSAGES (Tin nhắn)
-- ===========================
CREATE TABLE ChatMessages (
    message_id INT IDENTITY(1,1) PRIMARY KEY,
    sender_id INT FOREIGN KEY REFERENCES Users(user_id),
    receiver_id INT FOREIGN KEY REFERENCES Users(user_id),
    content NVARCHAR(MAX),
    message_type VARCHAR(20) CHECK (message_type IN ('text', 'image', 'video', 'call')),
    sent_at DATETIME DEFAULT GETDATE(),
    is_deleted_sender BIT DEFAULT 0,
    is_deleted_receiver BIT DEFAULT 0,
);

-- ===========================
-- REACTIONS (Cảm xúc tin nhắn)
-- ===========================
CREATE TABLE Reactions (
    reaction_id INT IDENTITY(1,1) PRIMARY KEY,
    message_id INT FOREIGN KEY REFERENCES ChatMessages(message_id) ON DELETE CASCADE,
    user_id INT FOREIGN KEY REFERENCES Users(user_id),
    reaction_type VARCHAR(20) CHECK (reaction_type IN ('like', 'love', 'haha', 'angry', 'sad')),
    reacted_at DATETIME DEFAULT GETDATE()
);

-- ===========================
-- BLOCKS (Chặn người dùng)
-- ===========================
CREATE TABLE Blocks (
    block_id INT IDENTITY(1,1) PRIMARY KEY,
    blocker_id INT FOREIGN KEY REFERENCES Users(user_id),
    blocked_id INT FOREIGN KEY REFERENCES Users(user_id),
    blocked_at DATETIME DEFAULT GETDATE()
);

-- ===========================
-- VIP_PLANS (Gói VIP)
-- ===========================
CREATE TABLE VipPlans (
    vip_id INT IDENTITY(1,1) PRIMARY KEY,
    vip_name NVARCHAR(50),
    price DECIMAL(10,2),
    duration_days INT,
    benefits NVARCHAR(255)
);

-- ===========================
-- PAYMENTS (Thanh toán)
-- ===========================
CREATE TABLE Payments (
    payment_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT FOREIGN KEY REFERENCES Users(user_id),
    vip_id INT FOREIGN KEY REFERENCES VipPlans(vip_id),
    amount DECIMAL(10,2),
    payment_date DATETIME DEFAULT GETDATE(),
    status VARCHAR(20) CHECK (status IN ('success', 'pending', 'failed'))
);

-- ===========================
-- NOTIFICATIONS (Thông báo)
-- ===========================
CREATE TABLE Notifications (
    notification_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT FOREIGN KEY REFERENCES Users(user_id),
    title NVARCHAR(255),
    content NVARCHAR(1000),
    created_at DATETIME DEFAULT GETDATE(),
);
