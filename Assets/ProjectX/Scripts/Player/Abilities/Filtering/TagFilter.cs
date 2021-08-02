using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProjectX.Scripts.Player.Abilities.Filtering
{
    [CreateAssetMenu(fileName = "filter_tag", menuName = "Abilities/Filter/Tags")]
    public class TagFilter : FilterStrategy
    {
        [SerializeField] private string[] filterTags;
        
        public override IEnumerable<GameObject> Filter(IEnumerable<GameObject> targets)
        {
            return targets.Where(target => !(filterTags.Contains(target.tag) ^ includeFiltered));
        }
    }
}