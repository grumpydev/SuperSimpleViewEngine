Super Simple View Engine
========================

A super simple regex based view engine used in [Nancy](https://github.com/thecodejunkie/Nancy) and (soon to be) [TiinyTemplates](https://github.com/grumpydev/TinyTemplates).

Syntax
------

All commands have an optional semi-colon delimiter which can be used to remove ambiguity. Any [.Parameters] paraneter can be multiple levels deep (e.g. This.Property.That.Property).

### Standard variable substitution
Syntax: @Model[.Parameters]
Example: Hello @Model.Name
Example: Hello @Model.User.Age

Replaces with the string representation of the parameter, or the model itself if a parameter is not specified.

### Iterators
Syntax: @Each[.Parameters] [@Current[.Parameters]] @EndEach
Example: @Each.Users Hello @Current! @EndEach

Creates one copy of the contents of the @Each per element in the collection and substitutes @Current in the same way as @Model, but bound to the current item in the collection.

@Current can be used multiple times inside the @Each block.


