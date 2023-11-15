using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sentenceapp_backend.Models;

namespace sentenceapp_backend
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context) {
         //   context.Database.EnsureCreated();

            if (!context.Database.CanConnect())
            {
                context.Database.EnsureCreated();
            }
            else
            {
                context.Database.Migrate();
            }

            //string baseDirectory = AppContext.BaseDirectory;
            string baseDirectory = Directory.GetCurrentDirectory();
           // string filePath = Path.Combine(baseDirectory, "\\mockdata\\words.json");
            string filePath = baseDirectory + "\\mockdata\\words.json";

            var jsonData = File.ReadAllText(filePath);
            var wordData = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(jsonData);

            if(wordData != null )
            {
                foreach (var tableName in wordData.Keys)
                {
                    //if (context.Set<WordBaseClass>().Any(e => e.TableName == tableName))
                    //{
                    //    continue; // Data for this table has been seeded
                    //}

                    // Add your initial data for the table
                    switch (tableName)
                    {
                        case "nouns":
                            if (context.Set<Noun>().Any(e => e.Value != null))
                            {
                                continue; // Data for this table has been seeded
                            }
                            var nouns = wordData[tableName].Select(value => new Noun { Value = value });
                            context.Set<Noun>().AddRange(nouns);
                            break;

                        case "verbs":
                            if (context.Set<Verb>().Any(e => e.Value != null))
                            {
                                continue; // Data for this table has been seeded
                            }
                            var verbs = wordData[tableName].Select(value => new Verb { Value = value });
                            context.Set<Verb>().AddRange(verbs);
                            break;

                        case "adverbs":
                            if (context.Set<Adverb>().Any(e => e.Value != null))
                            {
                                continue; // Data for this table has been seeded
                            }
                            var adverbs = wordData[tableName].Select(value => new Adverb { Value = value });
                            context.Set<Adverb>().AddRange(adverbs);
                            break;
                        case "adjectives":
                            if (context.Set<Adjective>().Any(e => e.Value != null))
                            {
                                continue; // Data for this table has been seeded
                            }
                            var adjectives = wordData[tableName].Select(value => new Adjective { Value = value });
                            context.Set<Adjective>().AddRange(adjectives);
                            break;
                        case "prepositions":
                            if (context.Set<Preposition>().Any(e => e.Value != null))
                            {
                                continue; // Data for this table has been seeded
                            }
                            var prepositions = wordData[tableName].Select(value => new Preposition { Value = value });
                            context.Set<Preposition>().AddRange(prepositions);
                            break;
                        case "conjunctions":
                            if (context.Set<Conjunction>().Any(e => e.Value != null))
                            {
                                continue; // Data for this table has been seeded
                            }
                            var conjunctions = wordData[tableName].Select(value => new Conjunction { Value = value });
                            context.Set<Conjunction>().AddRange(conjunctions);
                            break;
                        case "pronouns":
                            if (context.Set<Pronoun>().Any(e => e.Value != null))
                            {
                                continue; // Data for this table has been seeded
                            }
                            var pronouns = wordData[tableName].Select(value => new Pronoun { Value = value });
                            context.Set<Pronoun>().AddRange(pronouns);
                            break;
                        case "exclamations":
                            if (context.Set<Adverb>().Any(e => e.Value != null))
                            {
                                continue; // Data for this table has been seeded
                            }
                            var exclamations = wordData[tableName].Select(value => new Exclamation { Value = value });
                            context.Set<Exclamation>().AddRange(exclamations);
                            break;
                        case "determiners":
                            if (context.Set<Determiner>().Any(e => e.Value != null))
                            {
                                continue; // Data for this table has been seeded
                            }
                            var determiners = wordData[tableName].Select(value => new Determiner { Value = value });
                            context.Set<Determiner>().AddRange(determiners);
                            break;

                        default:
                            break;
                    }

                    context.SaveChanges();
                }
            }

        }
    }
}
