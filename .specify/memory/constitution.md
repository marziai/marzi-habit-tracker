<!--
Sync Impact Report
- Version change: 0.0.0 -> 1.0.0
- Modified principles: none (initial constitution)
- Added sections: Architecture & Technology Standards, Development Workflow
- Removed sections: none
- Follow-up TODOs: none
-->

# Marzi Habit Tracker Constitution

## Core Principles

### I. Clean Code and Intentional Design
Every feature, service, endpoint, component, and repository MUST be clear, single-purpose, and easy to reason about. Code that is difficult to read or overly clever MUST be justified with a clear business or technical need and documented in the implementation or review notes.

Rationale: maintainability is a product requirement. When code is easy to understand, changes are safer, onboarding is faster, and defects are easier to isolate.

### II. Architecture Integrity
The application MUST remain a cohesive, maintainable system with explicit boundaries between presentation, application logic, and persistence. The solution MUST avoid mixing UI logic, business rules, and data access in the same layer or component.

Rationale: a single product can still be disciplined if responsibilities remain separated and predictable.

### III. Data Access Through Abstractions
All database interaction MUST occur through repository or service abstractions rather than ad hoc queries embedded directly inside controllers, endpoints, or UI code. Persistence logic MUST be centralized, testable, and consistent across the application.

Rationale: centralized data access reduces duplication, improves testability, and makes schema or storage changes safer.

### IV. Quality Through Verification
Changes MUST be validated with automated checks before merge. New or modified behavior MUST have focused tests that prove the expected contract, and regressions MUST be caught before release.

Rationale: verification is the mechanism that keeps the system honest and protects the product from unintentional breaks.

### V. Simplicity and Change Safety
The project MUST prefer the simplest correct solution that satisfies the current requirement. New abstractions, frameworks, or patterns MUST be introduced only when the added complexity is necessary and the long-term benefit is clear.

Rationale: simplicity reduces maintenance cost, improves predictability, and makes change safer for future contributors.

## Architecture & Technology Standards
The application architecture MUST be a clean, tightly-coupled monolithic or closely integrated API plus single-page application pattern. The backend MUST use C# with .NET Minimal APIs or controllers, and Entity Framework Core with SQLite as the persistence layer. The frontend MUST use React with Vite and Tailwind CSS.

The project MUST maintain clear layering and avoid spreading business rules or persistence logic across presentation code. Any new database access path MUST fit the repository or service pattern and MUST be consistent with the rest of the system.

Rationale: explicit technology choices reduce uncertainty, keep the stack coherent, and provide a stable foundation for delivery and maintenance.

## Development Workflow
All work MUST be submitted through a review process that checks compliance with this constitution. Pull requests MUST confirm that the change matches the agreed architecture, that data access remains within the repository/service pattern, and that required validation has been performed.

The project MUST record meaningful decisions when a change affects architecture, contracts, or persistence boundaries. When a change introduces risk or complexity, the rationale MUST be stated in the work item, design note, or code review discussion.

Rationale: good review discipline keeps the codebase aligned with the constitution and prevents architectural drift.

## Governance
This constitution supersedes ad hoc development practices and establishes the non-negotiable rules for this repository. Amendments require explicit documentation, review, and a clear explanation of the impact on the existing system.

Changes to this constitution MUST preserve the project's intent to produce a clean, maintainable, verifiable application. Any amendment that introduces a new principle, materially expands a section, or removes a requirement MUST include an impact review describing the migration or compliance implications.

All contributors MUST review changes for compliance with the principles above. The project MUST treat this constitution as a living governance document, but the base expectations remain fixed unless an amendment is formally approved and versioned.

**Version**: 1.0.0 | **Ratified**: 2026-10-05 | **Last Amended**: 2026-10-05
