using Microsoft.EntityFrameworkCore;
using sentenceapp_backend.Models;

namespace sentenceapp_backend
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Noun> Nouns { get; set; }
        public DbSet<Verb> Verbs { get; set; }
        public DbSet<Adverb> Adverbs { get; set; }
        public DbSet<Adjective> Adjectives { get; set; }
        public DbSet<Conjunction> Conjunctions { get; set; }
        public DbSet<Determiner> Determiners { get; set; }
        public DbSet<Exclamation> Exclamations { get; set;}
        public DbSet<Preposition> Prepositions { get; set; }
        public DbSet<Pronoun> Pronouns { get; set; }
        public DbSet<Sentence> Sentences { get; set; }
    }
}
