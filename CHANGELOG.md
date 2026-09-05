# Changelog

All notable changes to Pure.Primitives.Cached are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [1.1.3] — 2026-06-25

- Maintenance release: dependency and build updates.

## [1.1.2] — 2026-05-28

- Maintenance release: dependency and build updates.

## [1.1.1] — 2026-05-07

- Maintenance release: dependency and build updates.

## [1.1.0] — 2025-12-10

### Added

- Multi-targeting: the package now also targets `net7.0`, `net8.0`, and
  `net10.0`, in addition to `net9.0`.

## [1.0.0] — 2025-11-02

### Fixed

- `CachedBool.BoolValue`, `CachedChar.CharValue`,
  `CachedDayOfWeek.DayNumberValue`, `CachedGuid.GuidValue`,
  `CachedNumber<T>.NumberValue`, and `CachedString.TextValue` are now
  public properties instead of explicit interface implementations, so
  the cached value can be read directly from the concrete type without
  casting to the wrapped `Pure.Primitives.Abstractions` interface.

### Added

- Package marked AOT- and trimming-compatible (`IsAotCompatible`).

## [0.1.0] — 2025-06-11

### Added

- Initial release with memoized wrappers for every `Pure.Primitives.Abstractions`
  primitive: `CachedBool`, `CachedChar`, `CachedString`, `CachedNumber<T>`,
  `CachedGuid`, `CachedDayOfWeek`, `CachedTime`, `CachedDate`, and
  `CachedDateTime`. Each is a `sealed record` that computes the wrapped
  value once on first access and caches it for all subsequent reads.
