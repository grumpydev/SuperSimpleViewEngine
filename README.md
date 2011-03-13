Super Simple View Engine
========================

A super simple regex based view engine used in [Nancy](https://github.com/thecodejunkie/Nancy) and (soon to be) [TinyTemplates](https://github.com/grumpydev/TinyTemplates).

Models can either be standard types, or ExpandoObjects (or any other object implementing IDynamicMetaObjectProvider that implements IDictionary<string, object> to access its properties).

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

### Conditionals
Syntax: @If[Not].Parameters [contents] @EndIf
Example: @If.HasUsers Users found! @EndIf
Example: @IfNot.HasUsers No users found! @EndIf

Parameters must be a boolean (see Implicit Conditionals below). Nesting of @If and @IfNot statements is not supported.

### Implicit Conditionals
If the model has property that implements ICollection then you can use an implicit conditional. The implicit conditional syntax is the same as a normal conditional, but the Parameters part is set to "Has[CollectionPropertyName]". The conditional will be true if the collection contains items, and false if it does not or if it is null.

Example: @If.HasUsers Users found! @EndIf

The above example will expand to "Users found!" if the model has a collection called "Users" and it contains items.
