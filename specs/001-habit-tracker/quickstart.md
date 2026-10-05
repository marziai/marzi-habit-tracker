# Quickstart: Personal Habit Tracker

## Prerequisites

- .NET SDK 8+
- Node.js 18+
- npm
- SQLite available via the .NET EF Core provider

## Backend

1. Navigate to `backend`.
2. Restore packages.
3. Configure the SQLite connection string.
4. Run EF Core migrations.
5. Start the API.
6. Verify the habit endpoints respond successfully.

## Frontend

1. Navigate to `frontend`.
2. Install dependencies with `npm install`.
3. Configure the API base URL.
4. Start the Vite development server.
5. Validate that the habit list, check-in view, and streak summary render correctly.

## Validation Scenarios

- Create a habit with a title and description.
- Update the habit details.
- Check the habit complete for today.
- Confirm the current streak increments appropriately.
- Confirm the longest streak retains the highest historical run.
- Delete a habit and confirm it disappears from the daily list.
