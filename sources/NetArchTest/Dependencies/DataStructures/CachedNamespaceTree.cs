namespace NetArchTest.Dependencies.DataStructures
{
    using System.Collections.Generic;
    using System.Linq;
    using Mono.Cecil;

    internal class CachedNamespaceTree : ISearchTree
    {
        /// <summary> The list of dependencies being searched for. </summary>
        private readonly NamespaceTree _searchTree;

        public int TerminatedNodesCount => _searchTree.TerminatedNodesCount;

        public CachedNamespaceTree(IEnumerable<string> dependencies)
        {
            _searchTree = new NamespaceTree(dependencies, true);
        }

        /// <summary>
        /// Searching a search tree is costly (it requires a lot of operations on strings like SubString, IndexOf).
        /// For a given type we always get the same answer, so let us cache what search tree returns.
        /// </summary>
        private readonly TypeReferenceTree<string[]> _cachedAnswersFromSearchTree = new();
        public IEnumerable<string> GetAllMatchingNames(TypeReference type)
        {
            var node = _cachedAnswersFromSearchTree.GetNode(type);
            if (node.Value == null)
            {
                node.Value = _searchTree.GetAllMatchingNames(type).ToArray();
            }
            return node.Value;
        }

        public IEnumerable<string> GetAllMatchingNames(string fullName)
        {
            return _searchTree.GetAllMatchingNames(fullName).ToArray();
        }
    }
}