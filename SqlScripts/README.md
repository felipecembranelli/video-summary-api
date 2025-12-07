# SQL Migration Scripts

This directory contains SQL scripts generated from Entity Framework Core migrations.

## Files

- **InitialCreate.sql**: Complete SQL script for the InitialCreate migration, including:
  - CREATE TABLE statements for all tables
  - Foreign key constraints
  - Index creation statements
  - Commented-out DROP TABLE statements for rollback

- **InitialCreate_Rollback.sql**: Standalone rollback script that drops all tables created by InitialCreate migration

## Usage

### Apply Migration (Create Tables)

To apply the migration and create all tables, execute the `InitialCreate.sql` script:

```sql
-- Using SQL Server Management Studio (SSMS)
-- Open InitialCreate.sql and execute against your database

-- Using sqlcmd
sqlcmd -S your_server -d your_database -i InitialCreate.sql
```

### Rollback Migration (Drop Tables)

To rollback the migration and drop all tables, execute the `InitialCreate_Rollback.sql` script:

```sql
-- Using SQL Server Management Studio (SSMS)
-- Open InitialCreate_Rollback.sql and execute against your database

-- Using sqlcmd
sqlcmd -S your_server -d your_database -i InitialCreate_Rollback.sql
```

Alternatively, you can uncomment the DROP TABLE statements at the end of `InitialCreate.sql` and execute them.

## Database Schema Overview

The InitialCreate migration creates the following tables for a transplant organ matching system:

### Core Tables
- **Candidates**: Stores transplant candidates information
- **Donors**: Stores organ donors information
- **DonorProxies**: Stores specific organ information from donors

### Supporting Tables
- **CandidateClinicalSnapshots**: Clinical snapshots for candidates over time
- **Transplants**: Records of transplant procedures
- **MatchingRuns**: Algorithmic matching run records
- **MatchResults**: Individual match results between candidates and donor organs

### Key Relationships
- CandidateClinicalSnapshots → Candidates (foreign key: CandidateId)
- DonorProxies → Donors (foreign key: DonorId)
- MatchResults → DonorProxies (foreign key: DonorProxyId)
- MatchResults → MatchingRuns (foreign key: MatchingRunId)

## Notes

- All scripts use SQL Server syntax (T-SQL)
- Primary keys are UNIQUEIDENTIFIER (GUID) type
- Several tables have default values for Status columns
- Indexes are created for frequently queried columns to improve performance
- Foreign keys use CASCADE delete for related records
