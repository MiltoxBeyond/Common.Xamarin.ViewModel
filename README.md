# Common.Xamarin.ViewModel
Common Xamarin ViewModel to Help with Property Relationships

## Purpose
This library was created to eliminate some of the boilerplating that is needed to have a useful viewmodel in Xamarin (or WPF). 

## Basic Usage

Create a viewmodel that extends `BaseViewModel` to have access to the built in features of the library. 

```csharp
public class ExampleViewModel : Common.Xamarin.ViewModel {
	
	//Basic Examples
	public string Title { 
		get => GetValue<string>(); 
		set => SetValue(value); 
	}

	public int Count {
		get => GetValue<int>();
		set => SetValue(value);
	}
}
```

## Extended Usage (Relationships)

```csharp

using Common.Xamarin.ViewModel.Attributes;

//...

public class RelationshipViewModel : Common.Xamarin.ViewModel {
	//Basic Examples
	//This value affects IsValid
	public string Title { 
		get => GetValue<string>(); 
		set => SetValue(value); 
	}

	//This Value Affects both Message and IsValid
	[Affects(nameof(Message))]
	public int Count {
		get => GetValue<int>();
		set => SetValue(value);
	}

	[AffectedBy(nameof(Title), nameof(Count))]
	public bool IsValid => Count > 0 && !string.IsNullOrEmpty(Title);

	//This one could also be AffectedBy Count.
	public string Message => $"The total count is: {Count}";
}
```

## Additional

### Triggers on Change
Technically you can implement triggers in a variety of ways including subscribing to the INotifyPropertyChanged Event, but that can usually be a little messy.
Instead you can implement Method Calls in either the getter or the setter of the properties to handle if you want to manipulate the old or new data.

Example:
```csharp
	///...
	public string Title { 
		get {
			var value = GetValue<string>();
			//Takes the newly stored value.  This getter is accessed on each Notified Change 
			//so it would execute after a change
			CallMethodWithNewValue(value); 
			return value;
		}
		set {
		  var oldValue = GetValue<string>(); //Optional if you need to compare the values or something along those lines
		  //Called everytime there is a change in the value of this particular property.
		  CallMethodWithBothValues(oldValue, value);
		  SetValue(value); 
		}
	}
```
