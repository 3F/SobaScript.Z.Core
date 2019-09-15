# [SobaScript.Z.Core](https://github.com/3F/SobaScript.Z.Core)

Core components for SobaScript. Extensible Modular Scripting Programming Language.

**-- #SobaScript**

https://github.com/3F/SobaScript

[![Build status](https://ci.appveyor.com/api/projects/status/i5lugbk4rgovi6ta/branch/master?svg=true)](https://ci.appveyor.com/project/3Fs/sobascript-z-core/branch/master)
[![release-src](https://img.shields.io/github/release/3F/SobaScript.Z.Core.svg)](https://github.com/3F/SobaScript.Z.Core/releases/latest)
[![License](https://img.shields.io/badge/License-MIT-74A5C2.svg)](https://github.com/3F/SobaScript.Z.Core/blob/master/License.txt)
[![NuGet package](https://img.shields.io/nuget/v/SobaScript.Z.Core.svg)](https://www.nuget.org/packages/SobaScript.Z.Core/)
[![Tests](https://img.shields.io/appveyor/tests/3Fs/sobascript-z-core/master.svg)](https://ci.appveyor.com/project/3Fs/sobascript-z-core/build/tests)

[![Build history](https://buildstats.info/appveyor/chart/3Fs/SobaScript.Z.Core?buildCount=20&showStats=true)](https://ci.appveyor.com/project/3Fs/SobaScript.Z.Core/history)

## License

Licensed under the [MIT License](https://github.com/3F/SobaScript.Z.Core/blob/master/License.txt)

```
Copyright (c) 2014-2019  Denis Kuzmin < x-3F@outlook.com > GitHub/3F
```

[ [ ☕ Donate ](https://3F.github.com/Donation/) ]

SobaScript.Z.Core contributors: https://github.com/3F/SobaScript.Z.Core/graphs/contributors

## Provides at least the following

### ConditionComponent

Supports composite conditions with limited short-circuit evaluation (separately for all brackets)

Additional Operators:

```text
 ===, !==, ~=, ==, !=, >=, <=, !, >, <, ^=, =^
```


```clojure
#[( #[var count] > 10 || ($(isAllow) && !false) ) {
    ...
}
else{
    ...
}]
```

```clojure
#[($(Configuration) ~= Deb && $(count) > 10 || $(Configuration) == "Release" ) {
    ...
}]
```

```clojure
#[( (1 < 2 && 2 == 2 && ( true || ((false || 2 >= 2) && (1 > 7 && true)))) )
{
    #[( #[var count] > 10 || ($(isAllow) && !false) ) {
        ...
    }
    else{
        ...
    }]
}]
```

```clojure
#[( !(1 > 2) ) {
    is greater
}]
```

### EvMSBuildComponent

Through [E-MSBuild](https://github.com/3F/E-MSBuild)

```clojure
#[$(...)]
```

```clojure
#[$(
    [System.Math]::Exp('$(
        [MSBuild]::Multiply(
            $([System.Math]::Log(10)), 
            4
        ))'
    )
)]
```

```clojure
#[var revBuild  = #[$(
                    [System.TimeSpan]::FromTicks('$(
                        [MSBuild]::Subtract(
                        $(tNow), 
                        $(tBase))
                    )')
                    .TotalMinutes
                    .ToString('0'))]]
```

### UserVariableComponent

Through [Varhead](https://github.com/3F/Varhead).

```clojure
#[var name = mixed value]
#[var name]
```

```clojure
#[var branchSha1 = #[IO sout("git", "rev-parse --short HEAD")]]
```

Unset variable:

```clojure
#[var -name]
```

Default value for variable:

```clojure
#[var +name]
```

### TryComponent

Protects from errors in try{...} block and handles it in catch{...}

```clojure
#[try
{ 
    ...
}
catch(err, msg)
{
    $(err) - Type of Exception
    $(msg) - Error Message
    ...
}]
```

```clojure
#[try
{ 
     #[IO copy.file("notreal.file", "artefact.t1", false)]
}
catch(err, msg)
{
    #[($(err) == System.IO.FileNotFoundException) {
        #[OWP item("-Build-").writeLine(true): Found error #[$(msg)]]
    }]        
}]
```

```clojure
#[try {

    #[Box data.pack("header", false): 
    
        ...
    ]

}catch{ }]
```

### CommentComponent

```clojure
#["
    Example
          " Description 1 "
          " Description 2 "
"]
```

```clojure
#[" Example "]
```

### BoxComponent

Container of data for operations such for templating, repeating, etc.

```clojure
#[Box iterate(i = 0; $(i) < 10; i += 1): 
    ...
    #[Box operators.sleep(250)]
]
```

```clojure
#[Box repeat($(i) < 10; true): 

    #[File append("test.txt"): 
        #[$(i)] 
    ]

    $(i = $([MSBuild]::Add($(i), 1)))
]
```

```clojure
#[Box repeat($(flag)): ...]
#[Box iterate(; $(flag); ): ...]
```



```clojure
#[try {

    #[Box data.pack("header", false): 
    
        #[$(data = "Hello $(user) !")]
        #[File appendLine("$(fname)"): ------ #[$(data)] ------ ]
    ]

}catch{ }]

#[$(fname = 'f1.txt')]
#[$(user  = 'UserA')]
#[Box data.get("header", true)]

#[$(user = 'UserB')]
#[Box data.get("header", true)]
```

```
 ------ Hello UserA ! ------ 
 ------ Hello UserB ! ------ 
```