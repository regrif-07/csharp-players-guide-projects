var recentNumbers = new RecentNumbers();

var endlessRandomNumbersGenerator = new EndlessRandomNumbersGenerator(0, 9, 1000);
var endlessRandomNumbersGeneratorThread = new Thread(endlessRandomNumbersGenerator.StartGeneration);
endlessRandomNumbersGeneratorThread.Start(recentNumbers);

var endlessRandomNumbersUserObserver = new EndlessRandomNumbersUserObserver();
var endlessRandomNumbersUserObserverThread = new Thread(endlessRandomNumbersUserObserver.StartObservation);
endlessRandomNumbersUserObserverThread.Start(recentNumbers);