-- =============================================
-- Entity Framework Core Migration: InitialCreate
-- Generated SQL Statements for SQL Server
-- =============================================

-- =============================================
-- UP MIGRATION - Create Tables and Indexes
-- =============================================

-- Create Candidates Table
CREATE TABLE [Candidates] (
    [Id] uniqueidentifier NOT NULL,
    [Mrn] nvarchar(50) NOT NULL,
    [FirstName] nvarchar(100) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [Age] int NOT NULL,
    [BloodType] nvarchar(3) NOT NULL,
    [RegistrationDate] datetime2 NOT NULL,
    [Status] nvarchar(50) NOT NULL DEFAULT 'Active',
    CONSTRAINT [PK_Candidates] PRIMARY KEY ([Id])
);
GO

-- Create Donors Table
CREATE TABLE [Donors] (
    [Id] uniqueidentifier NOT NULL,
    [DonorId] nvarchar(50) NOT NULL,
    [FirstName] nvarchar(100) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [Age] int NOT NULL,
    [BloodType] nvarchar(3) NOT NULL,
    [DonationDate] datetime2 NOT NULL,
    [DonorType] nvarchar(50) NOT NULL,
    [HlaProfile] nvarchar(500) NOT NULL,
    [Status] nvarchar(50) NOT NULL DEFAULT 'Available',
    CONSTRAINT [PK_Donors] PRIMARY KEY ([Id])
);
GO

-- Create CandidateClinicalSnapshots Table
CREATE TABLE [CandidateClinicalSnapshots] (
    [Id] uniqueidentifier NOT NULL,
    [CandidateId] uniqueidentifier NOT NULL,
    [SnapshotDate] datetime2 NOT NULL,
    [PraPercentage] int NOT NULL,
    [EptsScore] numeric(5,2) NOT NULL,
    [DialysisDurationMonths] int NOT NULL,
    [HlaAntibodies] nvarchar(500) NOT NULL,
    [ClinicalNotes] nvarchar(1000) NOT NULL,
    CONSTRAINT [PK_CandidateClinicalSnapshots] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CandidateClinicalSnapshots_Candidates_CandidateId] FOREIGN KEY ([CandidateId]) REFERENCES [Candidates] ([Id]) ON DELETE CASCADE
);
GO

-- Create DonorProxies Table
CREATE TABLE [DonorProxies] (
    [Id] uniqueidentifier NOT NULL,
    [DonorId] uniqueidentifier NOT NULL,
    [OrganType] nvarchar(50) NOT NULL,
    [QualityAssessment] nvarchar(50) NOT NULL,
    [ColdIschemiaTimeMinutes] int NOT NULL,
    [Status] nvarchar(50) NOT NULL DEFAULT 'Available',
    CONSTRAINT [PK_DonorProxies] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DonorProxies_Donors_DonorId] FOREIGN KEY ([DonorId]) REFERENCES [Donors] ([Id]) ON DELETE CASCADE
);
GO

-- Create Transplants Table
CREATE TABLE [Transplants] (
    [Id] uniqueidentifier NOT NULL,
    [TransplantId] nvarchar(50) NOT NULL,
    [CandidateId] uniqueidentifier NOT NULL,
    [DonorProxyId] uniqueidentifier NOT NULL,
    [TransplantDate] datetime2 NOT NULL,
    [Status] nvarchar(50) NOT NULL DEFAULT 'Scheduled',
    [SurgeonName] nvarchar(100) NOT NULL,
    [Facility] nvarchar(200) NOT NULL,
    [Notes] nvarchar(1000) NOT NULL,
    CONSTRAINT [PK_Transplants] PRIMARY KEY ([Id])
);
GO

-- Create MatchingRuns Table
CREATE TABLE [MatchingRuns] (
    [Id] uniqueidentifier NOT NULL,
    [DonorProxyId] uniqueidentifier NOT NULL,
    [RunDate] datetime2 NOT NULL,
    [AlgorithmVersion] nvarchar(50) NOT NULL,
    [TotalCandidatesMatched] int NOT NULL,
    [Status] nvarchar(50) NOT NULL DEFAULT 'Completed',
    [Notes] nvarchar(1000) NOT NULL,
    CONSTRAINT [PK_MatchingRuns] PRIMARY KEY ([Id])
);
GO

-- Create MatchResults Table
CREATE TABLE [MatchResults] (
    [Id] uniqueidentifier NOT NULL,
    [MatchingRunId] uniqueidentifier NOT NULL,
    [DonorProxyId] uniqueidentifier NOT NULL,
    [CandidateId] uniqueidentifier NOT NULL,
    [MatchScore] numeric(5,2) NOT NULL,
    [HlaScore] numeric(5,2) NOT NULL,
    [BloodTypeScore] numeric(5,2) NOT NULL,
    [WaitingTimeScore] numeric(5,2) NOT NULL,
    [AgeScore] numeric(5,2) NOT NULL,
    [GeographicScore] numeric(5,2) NOT NULL,
    [Rank] int NOT NULL,
    [Status] nvarchar(50) NOT NULL DEFAULT 'Matched',
    [CreatedDate] datetime2 NOT NULL,
    [Notes] nvarchar(1000) NOT NULL,
    CONSTRAINT [PK_MatchResults] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MatchResults_DonorProxies_DonorProxyId] FOREIGN KEY ([DonorProxyId]) REFERENCES [DonorProxies] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MatchResults_MatchingRuns_MatchingRunId] FOREIGN KEY ([MatchingRunId]) REFERENCES [MatchingRuns] ([Id]) ON DELETE CASCADE
);
GO

-- =============================================
-- Create Indexes
-- =============================================

-- Indexes for CandidateClinicalSnapshots
CREATE INDEX [IX_CandidateClinicalSnapshots_CandidateId] ON [CandidateClinicalSnapshots] ([CandidateId]);
GO

CREATE INDEX [IX_CandidateClinicalSnapshots_SnapshotDate] ON [CandidateClinicalSnapshots] ([SnapshotDate]);
GO

-- Indexes for Candidates
CREATE UNIQUE INDEX [IX_Candidates_Mrn] ON [Candidates] ([Mrn]);
GO

CREATE INDEX [IX_Candidates_Status] ON [Candidates] ([Status]);
GO

-- Indexes for DonorProxies
CREATE INDEX [IX_DonorProxies_DonorId] ON [DonorProxies] ([DonorId]);
GO

CREATE INDEX [IX_DonorProxies_Status] ON [DonorProxies] ([Status]);
GO

-- Indexes for Donors
CREATE UNIQUE INDEX [IX_Donors_DonorId] ON [Donors] ([DonorId]);
GO

CREATE INDEX [IX_Donors_Status] ON [Donors] ([Status]);
GO

-- Indexes for MatchingRuns
CREATE INDEX [IX_MatchingRuns_DonorProxyId] ON [MatchingRuns] ([DonorProxyId]);
GO

CREATE INDEX [IX_MatchingRuns_RunDate] ON [MatchingRuns] ([RunDate]);
GO

CREATE INDEX [IX_MatchingRuns_Status] ON [MatchingRuns] ([Status]);
GO

-- Indexes for MatchResults
CREATE INDEX [IX_MatchResults_CandidateId] ON [MatchResults] ([CandidateId]);
GO

CREATE INDEX [IX_MatchResults_CreatedDate] ON [MatchResults] ([CreatedDate]);
GO

CREATE INDEX [IX_MatchResults_DonorProxyId] ON [MatchResults] ([DonorProxyId]);
GO

CREATE INDEX [IX_MatchResults_MatchingRunId] ON [MatchResults] ([MatchingRunId]);
GO

CREATE INDEX [IX_MatchResults_Status] ON [MatchResults] ([Status]);
GO

-- Indexes for Transplants
CREATE INDEX [IX_Transplants_CandidateId] ON [Transplants] ([CandidateId]);
GO

CREATE INDEX [IX_Transplants_DonorProxyId] ON [Transplants] ([DonorProxyId]);
GO

CREATE INDEX [IX_Transplants_Status] ON [Transplants] ([Status]);
GO

CREATE UNIQUE INDEX [IX_Transplants_TransplantId] ON [Transplants] ([TransplantId]);
GO

-- =============================================
-- DOWN MIGRATION - Drop Tables
-- =============================================

/*
-- Uncomment the following section to execute the DOWN migration (rollback)

-- Drop MatchResults Table
DROP TABLE IF EXISTS [MatchResults];
GO

-- Drop CandidateClinicalSnapshots Table
DROP TABLE IF EXISTS [CandidateClinicalSnapshots];
GO

-- Drop Transplants Table
DROP TABLE IF EXISTS [Transplants];
GO

-- Drop MatchingRuns Table
DROP TABLE IF EXISTS [MatchingRuns];
GO

-- Drop DonorProxies Table
DROP TABLE IF EXISTS [DonorProxies];
GO

-- Drop Candidates Table
DROP TABLE IF EXISTS [Candidates];
GO

-- Drop Donors Table
DROP TABLE IF EXISTS [Donors];
GO
*/
