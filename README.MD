# KTT ScopeTest

Goal: check if we can set a label from multipe sources in a unified way. The label should not be changable at runtime.


## Sources

The label can come from the following sources:

- Based of the URL
- Based on a routing attribute called Label
	- set on the controller
	- set on the action
- Explicitly set by the LabelContextProvider

## Obvervations

Thinks to think about: 

- When the label if not correct, the HTTP request should be rejected with a HTTP 400, not a HTTP 500.
- DI must account for the label, or you'll get timing problems. You cannot change score afterwards. 
  Upon instantiating all objects should be set.
- In background services this is fine, as we use `serviceScopeFactory.CreateScope`, 
  then we init `LabelContextProvider` and then we create the actual service, so we're
  having the right context. Thi