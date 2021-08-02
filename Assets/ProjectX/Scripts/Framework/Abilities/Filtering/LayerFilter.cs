using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Filtering
{
    [CreateAssetMenu(fileName = "filter_layer", menuName = "Abilities/Filter/Layers")]
    public class LayerFilter : FilterStrategy
    {
        [SerializeField] private string[] filterLayers;
        
        private int _layerMask;

        private void Awake()
        {
            _layerMask = LayerMask.GetMask(filterLayers);
        }

        public override IEnumerable<GameObject> Filter(IEnumerable<GameObject> targets)
        {
            return targets.Where(target => ((1 << target.layer) & _layerMask) == 0 ^ includeFiltered);
        }
    }
}