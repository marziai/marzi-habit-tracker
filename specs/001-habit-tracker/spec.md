# Feature Specification: Personal Habit Tracker

**Feature Branch**: `001-habit-tracker`

**Created**: 2026-10-05

**Status**: Draft

**Input**: User description: "Create a Personal Habit Tracker system. Users can create, update, and delete habits (giving them a title and description). Users can view a daily check-in matrix or list to mark habits as completed for today. The system must calculate and display the user's current streak (consecutive days completed) and longest streak for each habit."

## User Scenarios & Testing *(mandatory)*

### User Story 1 - Manage personal habits (Priority: P1)

A user wants to keep a list of habits they are trying to build and maintain. They need to create new habits with a title and description, update details when plans change, and remove habits they no longer want to track.

**Why this priority**: Habit tracking starts with a clear and accurate list of routines. If people cannot manage their habits reliably, the rest of the feature set has little value.

**Independent Test**: A user can create, edit, and delete habits from a single interface and see the updated habit list immediately.

**Acceptance Scenarios**:

1. **Given** the user is on the habits page, **When** they create a habit with a title and description, **Then** the habit appears in their habit list with the provided details.
2. **Given** an existing habit, **When** the user updates its title or description, **Then** the saved details reflect the new values in the habit list.
3. **Given** an existing habit, **When** the user deletes it, **Then** it is removed from the habit list and no longer appears in daily check-ins.

---

### User Story 2 - Check in on habits for today (Priority: P1)

A user wants to mark the habits they completed today in a quick and simple way. They need to see the habits available for check-in and record completions without friction.

**Why this priority**: The daily completion flow provides the core habit-tracking value and drives every streak calculation.

**Independent Test**: A user can open a daily view, mark one or more habits complete for today, and see those completions reflected immediately.

**Acceptance Scenarios**:

1. **Given** a user has one or more habits, **When** they mark a habit complete for today, **Then** the habit is recorded as completed for that date.
2. **Given** a habit is already marked complete for today, **When** the user marks it again, **Then** the system prevents a duplicate completion for the same day.
3. **Given** the user has not completed a habit for today, **When** they view the daily habit list, **Then** the incomplete habit is clearly identified as pending.

---

### User Story 3 - Track streak progress (Priority: P1)

A user wants to see how consistently they are maintaining their habits over time. They need the current streak and longest streak for each habit to understand momentum and progress.

**Why this priority**: Streaks provide motivation and are a central part of the habit-tracking experience. They transform daily check-ins into a progress signal.

**Independent Test**: A user can view a habit card or row showing the current streak and longest streak, and the values update when daily completions change.

**Acceptance Scenarios**:

1. **Given** a habit has been completed on consecutive days, **When** the user views the habit details, **Then** the current streak reflects the number of consecutive completed days.
2. **Given** a habit has had a longer run of consecutive completions in the past, **When** the user views the habit details, **Then** the longest streak reflects the highest historical consecutive count.
3. **Given** a user misses a day for a habit, **When** the streak is recalculated, **Then** the current streak resets appropriately while the longest streak remains preserved.

---

### Edge Cases

- What happens when a user creates a habit with a blank title or missing description?
- How does the system handle check-ins for future dates or dates before the habit was created?
- What happens when a user edits a habit after it already has completion history?
- How does the system treat duplicates when a user tries to log the same habit more than once for the same date?
- What happens when a user has no completions yet for a habit?

## Requirements *(mandatory)*

### Functional Requirements

- **FR-001**: The system MUST allow a user to create a habit with a title and description.
- **FR-002**: The system MUST allow a user to update a habit's title and description after creation.
- **FR-003**: The system MUST allow a user to delete a habit from the tracked list.
- **FR-004**: The system MUST display the user's habits in a clear daily check-in view.
- **FR-005**: The system MUST allow a user to mark a habit as complete for the current day.
- **FR-006**: The system MUST prevent duplicate completion entries for the same habit on the same date.
- **FR-007**: The system MUST show whether each habit is complete or incomplete for the current day.
- **FR-008**: The system MUST calculate and display each habit's current streak as the consecutive number of completed days up to today.
- **FR-009**: The system MUST calculate and display each habit's longest streak as the highest consecutive completed-day sequence ever achieved for that habit.
- **FR-010**: The system MUST recalculate streak values whenever a completion is added, removed, or updated.
- **FR-011**: The system MUST allow a user to view recent daily completion history in a list or matrix format for habit tracking.
- **FR-012**: The system MUST preserve habit and completion data so that streak calculations remain available across sessions.
- **FR-013**: The system MUST handle incomplete or missing habit data gracefully by showing an empty or zero state for streak values and daily status.

### Key Entities *(include if feature involves data)*

- **User**: Represents an individual using the habit tracker. A user owns and manages their personal habits and daily completion records.
- **Habit**: Represents a recurring behavior the user is tracking. Each habit has a title, description, creation data, and a history of completion records.
- **HabitCompletion**: Represents a single date on which a user completed a habit. It links a habit to a specific date and is used to calculate streak metrics.
- **Streak Summary**: Represents the derived metrics for a habit, including the current streak and longest streak as measured from completion history.

## Success Criteria *(mandatory)*

### Measurable Outcomes

- **SC-001**: A user can create, edit, and remove a habit in under 2 minutes without assistance.
- **SC-002**: A user can mark a habit complete for today in fewer than 3 actions from the main dashboard or habit list.
- **SC-003**: The system displays accurate current and longest streak values for every tracked habit after daily completion updates.
- **SC-004**: At least 90% of users can complete a daily check-in flow successfully on their first attempt during usability testing.
- **SC-005**: Streak calculations remain correct across at least 30 days of completion history for each tracked habit.

## Assumptions

- Users are tracking habits for themselves and do not require multi-user sharing in the initial version.
- A habit's daily completion state is evaluated against the current date in the user's local time context.
- If a habit has no completion history, its current streak and longest streak are treated as zero.
- The initial version focuses on a single-user personal tracker and does not include social sharing, gamification, or notifications.
- Habit titles are required, while descriptions are optional but supported when provided.
