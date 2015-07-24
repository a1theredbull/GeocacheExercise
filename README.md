# GeocacheExercise

Exercise for interview process

## Notes:
- I had trouble using Autofac to resolve the IGeocachingRepository in the custom UniqueNameValidationAttribute.  I could not find a way to use the Web API DependencyResolver correctly with a custom validation attribute.  I ended up registering a MVC DependencyResolver and using that to resolve the repository.  If I had more time, I would find the correct way with just the Web API DepedencyResolver!

## Next on list of upgrades (not done because of time constraints):
- Logging errors
- Adding unit testing on API (wished I did Test-Driven from the start)
- Adding pagination and other filters to get all functions
- Adding authentication system / ownership system
- Adding longitude latitude picker with Google Maps
