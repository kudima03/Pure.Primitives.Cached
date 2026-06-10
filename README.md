# Pure.Primitives.Cached

Memoized **Pure** primitive wrappers — evaluate the underlying value once and cache the result for all subsequent accesses.

[![.NET build & test](https://github.com/kudima03/Pure.Primitives.Cached/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.Cached/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Primitives.Cached/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.Cached/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Primitives.Cached)](https://www.nuget.org/packages/Pure.Primitives.Cached)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Primitives.Cached` wraps any `Pure.Primitives.Abstractions` interface implementation and ensures its underlying value is computed exactly once. The cached value is stored on first access and reused on every subsequent call — useful when the wrapped primitive is an expensive composed operation tree.

## Types

| Type | Wraps | Cached property |
|------|-------|-----------------|
| `CachedBool` | `IBool` | `BoolValue` |
| `CachedChar` | `IChar` | `CharValue` |
| `CachedString` | `IString` | `StringValue` |
| `CachedNumber<T>` | `INumber<T>` | `NumberValue` |
| `CachedGuid` | `IGuid` | `GuidValue` |
| `CachedDate` | `IDate` | `Day`, `Month`, `Year` |
| `CachedTime` | `ITime` | `Hour`, `Minute`, `Second`, etc. |
| `CachedDateTime` | `IDateTime` | `Date`, `Time` |
| `CachedDayOfWeek` | `IDayOfWeek` | `DayOfWeekValue` |

All types are `sealed record`s and implement the corresponding `Pure.Primitives.Abstractions` interface.

## Design Principles

- **Evaluate once** — the wrapped value is computed on first access; subsequent accesses return the cached value directly.
- **Transparent** — each `Cached*` type implements the same interface as its wrapped type, so it is a drop-in replacement.
- **AOT-compatible** — no reflection; fully compatible with Native AOT.

## Dependencies

- [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions) — Pure primitive interfaces
