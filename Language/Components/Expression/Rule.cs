
using System;
using System.Collections;
using System.Collections.Generic;

namespace Components
{
    public class Rule
    {
        private int ruleNumber;
        private ISymbol symbol;
        private int parsePosition;
        private ArrayList ruleSymbols;

        private static ISymbol END = new End();

        public Rule(ISymbol symbol)
        {
            this.symbol = symbol;
            this.parsePosition = 0;
            this.ruleSymbols = new ArrayList();
            this.ruleSymbols.Add(END);
        }

        public int Length()
        {
            return ruleSymbols.Count - 1;
        }

        public ISymbol GetSymbol()
        {
            return symbol;
        }

        public bool IsRuleFor(ISymbol symbol)
        {
            return this.symbol.Equals(symbol);
        }

        public int RuleNumber
        {
            get
            {
                return ruleNumber;
            }
            set
            {
                ruleNumber = value;
            }
        }

        public Rule AddSymbol(ISymbol symbol)
        {
            this.ruleSymbols.Remove(END);
            this.ruleSymbols.Add(symbol);
            this.ruleSymbols.Add(END);
            return this;
        }

        public ISymbol GetCurrentParseSymbol()
        {
            return (ISymbol)ruleSymbols[parsePosition];
        }

        public void SetParsePosition(int position)
        {
            this.parsePosition = position;
        }

        public void NextParsePosition()
        {
            if (!IsRuleParsed())
                this.parsePosition++;
        }

        public bool IsRuleParsed()
        {
            return GetCurrentParseSymbol().IsEndSymbol();
        }

        public IEnumerable<ISymbol> Symbols()
        {
            foreach (ISymbol ruleSymbol in this.ruleSymbols)
            {
                yield return ruleSymbol;
            }
        }

        public override string ToString()
        {
            string rule = "";
            rule = this.symbol.ToString() + " -> ";
            for (int index = 0; index < this.ruleSymbols.Count; index++)
            {
                if (index == this.parsePosition)
                    rule = rule + ".";
                rule = rule + this.ruleSymbols[index] + " ";
            }
            return rule;
        }

        public Rule Duplicate()
        {
            Rule duplicateRule = new Rule(this.symbol.Duplicate());
            foreach (ISymbol ruleSymbol in ruleSymbols)
            {
                if (ruleSymbol.IsEndSymbol())
                    continue;
                duplicateRule.AddSymbol(ruleSymbol.Duplicate());
            }
            duplicateRule.SetParsePosition(this.parsePosition);
            duplicateRule.ruleNumber = ruleNumber;
            return duplicateRule;
        }

    }
}
