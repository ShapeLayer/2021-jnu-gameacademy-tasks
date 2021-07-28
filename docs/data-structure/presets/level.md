# Level
[![indicator](https://img.shields.io/badge/-Data%20Structure%20%3E%20Presets%20%3E%20Level-brightgreen)](#) [![using](https://img.shields.io/badge/using-csharp-brightgreen)](#)  

Level data is used for constructing a ingame level.  

| Params | Details |
| :-: | --- |
| `type` | `str` Type of level. |
| `config` | [`config`](#Configuration) Configuration for map constructing. |
| `path` | `int[]` Blocktile Paths arranged in order. _[Detail Information](#Path)_ |
| `length` | `int` Length of map blocktile path. |
| `resource` | `TBD` Resource of map. |

## In case of determined path
| Params | Details |
| :-: | --- |
| `type` | `str` Type of level. |
| `config` | [`config`](#Configuration) Configuration for map constructing. |
| `path` | `int[]` Blocktile Paths arranged in order. |

```json
{
    "type": "determined",
    "config": {},
    "path": [0, 1, 2, 3]
}
```

## In case of random path
| Params | Details |
| :-: | --- |
| `type` | `str` Type of level. |
| `config` | [`config`](#Configuration) Configuration for map constructing. |
| `length` | `int` Length of map blocktile path. |

```json
{
    "type": "random",
    "config": {},
    "length": 10
}
```

----
## Datatypes
### Configuration
| Params | Details |
| :-: | --- |
| `duration` | `float` Limitation of playtime. |
| `follower` | [`follower`](#Follower) Follower. |

### Follower
```csharp
class Follower: HumanEntity
{
    public float speed;
}
```

| Params | Details |
| ... | `HumanEntity` |
| `speed` | `float` Following speed of following player. |

### Path
`Path` is `List` of `int` value.  

| Value | Direction |
| :-: | --- |
| `0` | Forward |
| `1` | Right |
| `2` | Left |
| `3` | Backward |
