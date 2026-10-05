# Research: Personal Habit Tracker

## Decision

Use a two-part architecture: a .NET Core Web API backend with SQLite + EF Core for persistence, and a React + Vite + Tailwind frontend with Axios for API calls. Habit tracking will be modeled around a `Habit` entity and a `HabitLog` entity, where logs represent a habit completion on a specific date.

## Rationale

This structure matches the project constitution and the feature requirement to maintain a clean separation between the API and the client while keeping the implementation simple and easy to reason about. SQLite is the appropriate default persistence choice for a local or lightweight application, and EF Core provides an idiomatic repository/service abstraction for data access.

## Alternatives Considered

- Single-project app: rejected because the project explicitly requires separate API and SPA concerns.
- PostgreSQL: rejected as a heavier local default than needed for a personal tracker.
- LocalStorage-only frontend: rejected because persistent server-side data and structured EF access are required for reliable streak calculations.

## Findings

- Habit streak logic is best derived from a date-based log table rather than stored as mutable counters.
- A `HabitLog` entry should be unique per `HabitId` + `Date` to prevent duplicate check-ins.
- Current streak and longest streak should be computed from the ordered log dates for each habit and not treated as independent user-entered values.
