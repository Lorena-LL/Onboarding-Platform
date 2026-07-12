# Setup

1. Clone this repository.
2. Create a new **ASP.NET Core + React (Vite)** project.
3. Copy the contents of this repository into the generated project.
4. Install frontend dependencies:
   ```bash
   cd frontend
   npm install
   ```
5. Start the frontend:
   ```bash
   npm run dev
   ```
6. The repository includes the SQLite database files (`meridian.db`, `meridian.db-shm`, `meridian.db-wal`), so no database setup is required.
7. Run the backend:
   ```bash
   dotnet build
   dotnet run --launch-profile https
   ```

## In the UI use the credentials:

**email:** lore@meridian.com

**password:** lore1234


## Other Info:

EF Core migrations are included but are not required unless you want to recreate the database.

Backend APIs can be seen in Swagger.