using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _people;

        private readonly Dictionary<ResultType, Func<IEnumerable<Result>, Result>> _dictionary = new Dictionary<ResultType, Func<IEnumerable<Result>, Result>>
                                                                                         {
                                                                                             { ResultType.Closest, Closest },
                                                                                             { ResultType.Furthest, Furthest }
                                                                                          };

        public Finder(List<Person> people)
        {
            _people = people;
        }

        public Result Find(ResultType resultType)
        {
            var results = new List<Result>();

            foreach (var person in _people)
            {
                Person person1 = person;
                results.AddRange(_people.Where(x => !x.Equals(person1)).Select(other => new Result { PersonOne = person1, PersonTwo = other }));
            }

            return results.Any() ? _dictionary[resultType](results) : new Result();
        }

        private static Result Closest(IEnumerable<Result> results)
        {
            return results.OrderBy(x => x.GetDelta()).First();
        }

        private static Result Furthest(IEnumerable<Result> results)
        {
            return results.OrderBy(x => x.GetDelta()).Last();
        }
    }
}