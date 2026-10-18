# Pokémon Emerald C → C# Type Cheat Sheet

A quick reference for translating the original [`pret/pokeemerald`](https://github.com/pret/pokeemerald) code into a C# class library.

**Primary source:** [`include/gba/types.h`](https://github.com/pret/pokeemerald/blob/master/include/gba/types.h). The tables distinguish exact-width type mappings from *design choices* that depend on how the C type is used.

## 1. Fixed-width integer typedefs

| Emerald C | C# | Bits | Range |
|---|---|---:|---|
| `u8` | `byte` | 8 | 0 to 255 |
| `u16` | `ushort` | 16 | 0 to 65,535 |
| `u32` | `uint` | 32 | 0 to 4,294,967,295 |
| `u64` | `ulong` | 64 | 0 to 18,446,744,073,709,551,615 |
| `s8` | `sbyte` | 8 | −128 to 127 |
| `s16` | `short` | 16 | −32,768 to 32,767 |
| `s32` | `int` | 32 | −2,147,483,648 to 2,147,483,647 |
| `s64` | `long` | 64 | −9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 |

**Naming:** `u` = unsigned; `s` = signed; number = bit width.

```c
u8 level = 5;
u16 species = 252;
u32 personality = 123456789;
s8 priority = -1;
```

```csharp
byte level = 5;
ushort species = 252;
uint personality = 123456789;
sbyte priority = -1;
```

## 2. Floating-point and boolean typedefs

| Emerald C | C# mapping | Notes |
|---|---|---|
| `f32` | `float` | 32-bit IEEE 754 floating point |
| `f64` | `double` | 64-bit IEEE 754 floating point |
| `bool8` | `bool` **or** `byte` | `bool` for logic; `byte` for exact 8-bit representation |
| `bool16` | `bool` **or** `ushort` | `ushort` for exact 16-bit representation |
| `bool32` | `bool` **or** `uint` | `uint` for exact 32-bit representation |

A C boolean typedef backed by an integer **is not automatically interchangeable with a C# `bool`** when translating binary layouts, pointer casts, or numeric operations.

## 3. `volatile` typedefs

The `v` prefix denotes C `volatile` (for example, `vu16` is a volatile unsigned 16-bit integer).

| Emerald C | Underlying C# type |
|---|---|
| `vu8`, `vu16`, `vu32`, `vu64` | `byte`, `ushort`, `uint`, `ulong` |
| `vs8`, `vs16`, `vs32`, `vs64` | `sbyte`, `short`, `int`, `long` |
| `vbool8`, `vbool16`, `vbool32` | `byte`, `ushort`, `uint` for exact-width storage |

**Important:** The table gives the *underlying value type*, **not** an exact translation of volatility. C and C# `volatile` have different restrictions and semantics. In particular, you cannot mark every listed C# integer field `volatile` (such as `ulong`, `long`, and `ushort`). For ordinary game logic, hardware volatility often need not be reproduced.

## 4. Common C constructs you'll encounter

These are **not all typedefs**; they are translation reminders.

| C | Common C# approach | Watch out for |
|---|---|---|
| `void` | `void` | Same basic meaning |
| `struct Foo` | `struct` or `class` | C structs are value aggregates; choose C# representation based on semantics |
| `enum` | `enum` | Choose explicit underlying type when size matters, e.g. `enum X : byte` |
| `const` | `const` / `readonly` | Different rules for compile-time constants |
| `#define VALUE 42` | `const`, enum, or static member | Macros are text substitution, not typed fields |
| `#define FUNC(x) ...` | method | Mind repeated macro-argument evaluation in C |
| `u8 *` | `byte[]`, `Span<byte>`, `ref byte`, or pointer | Depends on memory and ownership semantics |
| `const u8 *` | `ReadOnlySpan<byte>` or read-only data representation | C `const` is not equivalent to C# `readonly` references |
| `u8 array[16]` | `byte[]` (length 16) | C array layout may need explicit packing when interoperating |
| `NULL` | `null` for references | Null pointer and null reference aren't universally equivalent |
| `TRUE` / `FALSE` | `true` / `false` | Only if used as logical booleans |
| `typedef` | Usually no alias needed | Prefer normal C# primitive names |

## 5. Numeric behavior that matters for Emerald

### Overflow / RNG

C# can perform checked arithmetic, so use `unchecked` when emulating deliberate 32-bit wraparound:

```csharp
private static uint NextState(uint state)
{
    return unchecked(1103515245u * state + 24691u);
}

public ushort Random()
{
    _rngValue = NextState(_rngValue); // Keep full 32-bit RNG state!
    return (ushort)(_rngValue >> 16); // Return upper 16 bits.
}
```

### Casts and integer promotion

- In C#, arithmetic on `byte`, `sbyte`, `short`, or `ushort` is generally promoted to `int`; explicitly cast when storing a narrow result.
- Preserve **integer division**, order of operations, and intermediate widths when translating stat and damage formulas.
- Bit shifts, signedness, casts, and overflow can change deterministic results.
- `int` and `uint` are both 32-bit in C#. Do **not** replace `u32` with `int` just because the value currently fits.

### Binary data / save formats

If reproducing packed C structures, encrypted Pokémon data, or save-file layouts, field widths alone are not enough: **field order, alignment, packing, endianness, and serialization** also matter. A C# `struct` is not automatically binary-compatible with Emerald's in-memory C structures.

## 6. Fast lookup

```text
u8       → byte        s8       → sbyte
u16      → ushort      s16      → short
u32      → uint        s32      → int
u64      → ulong       s64      → long
f32      → float       f64      → double
bool8    → bool / byte (context-dependent)
bool16   → bool / ushort (context-dependent)
bool32   → bool / uint (context-dependent)
vu8      → byte underlying (C volatile qualifier)
vu16     → ushort underlying (C volatile qualifier)
vu32     → uint underlying (C volatile qualifier)
```

**Recommendation for `PokemonEmerald.Core`:** Use idiomatic C# primitive names (`byte`, `ushort`, `uint`), preserve exact numeric widths for faithful mechanics, and model game behavior separately from GBA hardware-specific memory access.
