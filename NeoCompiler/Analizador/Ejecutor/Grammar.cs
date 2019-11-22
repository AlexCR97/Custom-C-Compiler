﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.Ejecutor
{
    public abstract class Grammar
    {
        protected Dictionary<RHS[], string> Rules = new Dictionary<RHS[], string>();
        protected List<string> POS = new List<string>();

        public Grammar()
        {
            initStartRules();
            initProductionRules();
            initPOS();
        }

        public abstract void initStartRules();
        public abstract void initProductionRules();
        public abstract void initPOS();

        public RHS[] getRHS(string lhs)
        {
            RHS[] rhs = null;

            if (Rules.ContainsValue(lhs))
            {
                foreach (KeyValuePair<RHS[], string> kvp in Rules)
                {
                    if (kvp.Value == lhs)
                    {
                        rhs = kvp.Key;
                        break;
                    }
                }
            }

            return rhs;
        }

        public bool isPartOfSpeech(string s)
        {
            return POS.Contains(s);
        }

        public void addStartRule(string rule)
        {
            string[] words = rule.Split(null);
            addStartRule(words);
        }

        public void addStartRule(string[] words)
        {
            RHS[] rhs = { new RHS(words) };
            Rules.Add(rhs, "S");
        }

        public void addStartRules(List<string> rules)
        {
            RHS[] rhs = new RHS[rules.Count];

            for (int i = 0; i < rules.Count; i++)
            {
                string[] words = rules[i].Split(null);
                rhs[i] = new RHS(words);
            }

            Rules.Add(rhs, "S");
        }

        public void addStartRules(List<string[]> rules)
        {
            RHS[] rhs = new RHS[rules.Count];

            for (int i = 0; i < rules.Count; i++)
            {
                string[] words = rules[i];
                rhs[i] = new RHS(words);
            }

            Rules.Add(rhs, "S");
        }

        public void addProductionRule(string tag, string rule)
        {
            string[] words = rule.Split(null);
            addProductionRule(tag, words);
        }

        public void addProductionRule(string tag, string[] words)
        {
            RHS[] rhs = { new RHS(words) };
            Rules.Add(rhs, tag);
        }

        public void addProductionRules(string tag, List<string> rules)
        {
            RHS[] rhs = new RHS[rules.Count];

            for (int i = 0; i < rules.Count; i++)
            {
                string[] words = rules[i].Split(null);
                rhs[i] = new RHS(words);
            }

            Rules.Add(rhs, tag);
        }

        public void addProductionRules(string tag, List<string[]> rules)
        {
            RHS[] rhs = new RHS[rules.Count];

            for (int i = 0; i < rules.Count; i++)
            {
                string[] words = rules[i];
                rhs[i] = new RHS(words);
            }

            Rules.Add(rhs, tag);
        }

        public void addPOS(string pos)
        {
            POS.Add(pos);
        }

        private bool isTag(string word)
        {
            return word[0] == '<' && word[word.Length - 1] == '>';
        }
    }
}
