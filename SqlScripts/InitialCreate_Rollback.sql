-- =============================================
-- Entity Framework Core Migration: InitialCreate
-- ROLLBACK (DOWN) Migration Script
-- =============================================

-- Drop tables in reverse dependency order
-- Drop MatchResults first (has foreign keys to DonorProxies and MatchingRuns)
DROP TABLE IF EXISTS [MatchResults];
GO

-- Drop CandidateClinicalSnapshots (has foreign key to Candidates)
DROP TABLE IF EXISTS [CandidateClinicalSnapshots];
GO

-- Drop Transplants (no foreign keys defined in migration, but references other tables)
DROP TABLE IF EXISTS [Transplants];
GO

-- Drop MatchingRuns (no foreign keys to other tables)
DROP TABLE IF EXISTS [MatchingRuns];
GO

-- Drop DonorProxies (has foreign key to Donors)
DROP TABLE IF EXISTS [DonorProxies];
GO

-- Drop Candidates (referenced by CandidateClinicalSnapshots)
DROP TABLE IF EXISTS [Candidates];
GO

-- Drop Donors (referenced by DonorProxies)
DROP TABLE IF EXISTS [Donors];
GO
