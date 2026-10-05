# Tasks: Personal Habit Tracker

**Input**: Design documents from `/specs/001-habit-tracker/`

**Prerequisites**: plan.md (required), spec.md (required for user stories), research.md, data-model.md, contracts/

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Initialize the backend and frontend projects and establish the codebase structure required for the feature.

- [ ] T001 Create backend project structure in `backend/src/API`, `backend/src/Application`, `backend/src/Domain`, `backend/src/Infrastructure`, and `backend/src/Persistence`
- [ ] T002 Initialize .NET Web API project with EF Core and SQLite dependencies in `backend/*.csproj`
- [ ] T003 Initialize React + Vite + Tailwind frontend in `frontend/package.json`, `frontend/vite.config.*`, and `frontend/src/`
- [ ] T004 [P] Configure frontend API client and shared environment configuration in `frontend/src/api/client.ts` and `frontend/.env.example`

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Create the shared persistence and service foundation that all user stories depend on.

- [ ] T005 Create `Habit` and `HabitLog` domain models in `backend/src/Domain/Habit.cs` and `backend/src/Domain/HabitLog.cs` with required title and date semantics
- [ ] T006 Create `AppDbContext` and EF Core configuration in `backend/src/Persistence/AppDbContext.cs` with `DbSet<Habit>` and `DbSet<HabitLog>`
- [ ] T007 Add SQLite database initialization and migration scaffolding in `backend/src/Persistence/DatabaseInitializer.cs` and `backend/src/Persistence/Migrations/`
- [ ] T008 Implement repository abstractions for habits and logs in `backend/src/Infrastructure/Repositories/HabitRepository.cs` and `backend/src/Infrastructure/Repositories/HabitLogRepository.cs`
- [ ] T009 Implement application-level habit and streak services in `backend/src/Application/Services/HabitService.cs` and `backend/src/Application/Services/StreakCalculatorService.cs`
- [ ] T010 [P] Create API DTOs and mapping helpers in `backend/src/API/Models/HabitDto.cs`, `backend/src/API/Models/CreateHabitRequest.cs`, and `backend/src/API/Models/UpdateHabitRequest.cs`
- [ ] T011 Configure startup, JSON serialization, and dependency injection in `backend/src/API/Program.cs`

**Checkpoint**: Foundation ready - user story implementation can begin.

---

## Phase 3: User Story 1 - Manage personal habits (Priority: P1) 🎯 MVP

**Goal**: Allow a user to create, update, and delete habits with a title and description.

**Independent Test**: A user can create, edit, and remove a habit from the habit list and see the change immediately reflected in the UI.

### Implementation for User Story 1

- [ ] T012 [P] [US1] Implement `GET /api/habits`, `POST /api/habits`, `PUT /api/habits/{habitId}`, and `DELETE /api/habits/{habitId}` in `backend/src/API/Controllers/HabitsController.cs`
- [ ] T013 [US1] Implement create, update, and delete use cases in `backend/src/Application/Services/HabitService.cs` with required title validation and description handling
- [ ] T014 [P] [US1] Add frontend habit CRUD API calls in `frontend/src/api/habits.ts`
- [ ] T015 [US1] Build the habit list and form UI in `frontend/src/pages/HabitsPage.tsx` and `frontend/src/components/HabitForm.tsx`
- [ ] T016 [US1] Add empty, validation, and error states in `frontend/src/components/HabitForm.tsx` and `frontend/src/pages/HabitsPage.tsx`

**Checkpoint**: User Story 1 is functionally complete and independently testable.

---

## Phase 4: User Story 2 - Check in on habits for today (Priority: P1)

**Goal**: Let users mark habits complete for today and view the daily check-in state without duplicate entries.

**Independent Test**: A user can open the daily view, mark a habit complete for today, and confirm the item shows as complete without creating duplicate logs for the same date.

### Implementation for User Story 2

- [ ] T017 [P] [US2] Implement daily completion endpoints in `backend/src/API/Controllers/HabitLogsController.cs` for listing and creating habit logs
- [ ] T018 [US2] Implement unique daily completion logic and duplicate prevention in `backend/src/Application/Services/HabitLogService.cs`
- [ ] T019 [P] [US2] Add frontend API calls for habit logs in `frontend/src/api/habitLogs.ts`
- [ ] T020 [US2] Build the daily check-in UI in `frontend/src/components/TodayCheckinList.tsx` and `frontend/src/pages/DashboardPage.tsx`
- [ ] T021 [US2] Add completed/incomplete state indicators and date handling for the current day in `frontend/src/components/TodayCheckinList.tsx`
- [ ] T022 [US2] Validate duplicate prevention and current-day state display in `frontend/src/pages/DashboardPage.tsx`

**Checkpoint**: User Story 2 is complete and independently testable.

---

## Phase 5: User Story 3 - Track streak progress (Priority: P1)

**Goal**: Calculate and display each habit's current streak and longest streak from completion history.

**Independent Test**: A user can view a habit's streak values and confirm they update correctly after consecutive completions, missed days, and zero-history state.

### Implementation for User Story 3

- [ ] T023 [P] [US3] Implement streak calculation logic in `backend/src/Application/Services/StreakCalculatorService.cs` for consecutive-day sequences and longest run tracking
- [ ] T024 [US3] Extend habit response data with `currentStreak`, `longestStreak`, and `isCompletedToday` in `backend/src/API/Models/HabitDto.cs`
- [ ] T025 [P] [US3] Add frontend streak summary rendering in `frontend/src/components/HabitCard.tsx` and `frontend/src/components/HabitRow.tsx`
- [ ] T026 [US3] Wire the habit list and dashboard to display streak values after completion changes in `frontend/src/pages/HabitsPage.tsx` and `frontend/src/pages/DashboardPage.tsx`
- [ ] T027 [US3] Validate zero-history, consecutive-day, and missed-day conditions in `frontend/src/components/HabitCard.tsx`

**Checkpoint**: User Story 3 is complete and independently testable.

---

## Phase 6: Polish & Cross-Cutting Concerns

**Purpose**: Final validation, cleanup, and end-to-end verification across all stories.

- [ ] T028 [P] Review API validation, error handling, and duplicate prevention across `backend/src/API/` and `backend/src/Application/`
- [ ] T029 [P] Review frontend state updates, empty states, and UX consistency across `frontend/src/components/` and `frontend/src/pages/`
- [ ] T030 Run the quickstart validation scenarios described in `specs/001-habit-tracker/quickstart.md`
- [ ] T031 [P] Verify all habit and streak flows against the contract in `specs/001-habit-tracker/contracts/habit-api.yaml`

---

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: No dependencies; can start immediately.
- **Foundational (Phase 2)**: Depends on Setup completion and blocks all user stories.
- **User Stories (Phases 3-5)**: Each depends on Phase 2 completion and can be implemented in priority order or in parallel if staffed.
- **Polish (Phase 6)**: Depends on all desired story work being complete.

### User Story Dependencies

- **User Story 1 (US1)**: Can start after the foundational phase; no dependency on later stories.
- **User Story 2 (US2)**: Can start after the foundational phase; it depends on habit entities but is independently testable.
- **User Story 3 (US3)**: Can start after the foundational phase and should consume completion data from US1 and US2 but remains independently testable.

### Parallel Opportunities

- `T004` can run alongside the backend and frontend initialization tasks.
- `T010` can run in parallel with `T008` and `T009` once models and repositories are in place.
- `T012` and `T014` can proceed in parallel within US1 once the shared service layer is ready.
- `T017` and `T019` can proceed in parallel within US2.
- `T023` and `T025` can proceed in parallel within US3.
- `T028`, `T029`, and `T031` can run together during polish.

---

## Parallel Example: User Story 1

```bash
# Independent implementation work for US1 can happen in parallel once the foundation is ready
# Backend API work
Task: "Implement create/update/delete habits in backend/src/Application/Services/HabitService.cs"
Task: "Implement habits controller endpoints in backend/src/API/Controllers/HabitsController.cs"

# Frontend work
Task: "Add habit CRUD API calls in frontend/src/api/habits.ts"
Task: "Build the habit list and form UI in frontend/src/pages/HabitsPage.tsx"
```

---

## Implementation Strategy

### MVP First (User Story 1 Only)

1. Complete Phase 1 and Phase 2.
2. Complete User Story 1 in Phase 3.
3. Validate habit creation, update, and deletion independently.
4. Stop and confirm the core habit management flow works before moving to daily check-ins or streak logic.

### Incremental Delivery

1. Complete Setup + Foundational.
2. Deliver User Story 1 as the initial MVP.
3. Add User Story 2 for daily check-ins and duplicate prevention.
4. Add User Story 3 for streak calculations and display.
5. Finish with polish and end-to-end validation.

### Parallel Team Strategy

If multiple developers are available:

1. One developer completes Setup + Foundational.
2. Developer A builds the backend API and service layer.
3. Developer B builds the frontend pages and API client.
4. Once the base work is stable, the team can work on the daily logging and streak flows in parallel.

---

## Notes

- Every task includes a task ID, required checkbox format, and exact file path.
- Story-specific tasks include the proper `[US1]`, `[US2]`, or `[US3]` label.
- Setup and foundational phases have no story label.
- All tasks are written to support independent implementation and validation without additional context.
