# Data Model: Personal Habit Tracker

## Entities

### Habit

| Field | Type | Constraints | Notes |
|---|---|---|---|
| Id | int | Primary key, generated | Unique habit identifier |
| Title | string | Required, max 200 | Display name of the habit |
| Description | string | Optional | Additional context for the habit |
| CreatedAtUtc | DateTime | Required | Record creation timestamp |
| UpdatedAtUtc | DateTime | Required | Last update timestamp |

Relationships:
- A habit has many `HabitLog` entries.

### HabitLog

| Field | Type | Constraints | Notes |
|---|---|---|---|
| Id | int | Primary key, generated | Unique log identifier |
| HabitId | int | Required, foreign key | References parent habit |
| LogDate | DateOnly | Required | The date the habit was completed |
| CreatedAtUtc | DateTime | Required | Completion timestamp |

Constraints:
- `HabitId + LogDate` must be unique.
- Log date is the business key for daily completion tracking.

## Derived Values

### Current Streak

The current streak is the consecutive number of dates ending on today or the most recent date with a completion, counting backward while each date has a matching `HabitLog`.

### Longest Streak

The longest streak is the maximum number of consecutive days in the habit's log history, computed across all date sequences.

## Validation Rules

- Habit title must be non-empty after trimming.
- Habit description may be empty.
- A single habit cannot have duplicate logs for the same date.
- Streak metrics are derived from logs and are not stored as separate mutable fields.
