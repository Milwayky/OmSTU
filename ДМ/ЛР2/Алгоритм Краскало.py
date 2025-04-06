f = open('example_2.txt')
lines = f.readlines()
number_of_vertex = len(lines[0].split())

edges = []
for i in range(number_of_vertex):
    row = list(map(int, lines[i].split()))
    for j in range(i + 1, number_of_vertex):
        if row[j] != 0:
            edges.append((row[j], i + 1, j + 1))  # (вес, вершина1, вершина2)

edges.sort(key=lambda x: x[0])
vertex_labels = list(range(1, number_of_vertex + 1))

def find_component(v):
    return vertex_labels[v - 1]

# Объединение двух компонент
def union(v1, v2):
    comp1 = find_component(v1)
    comp2 = find_component(v2)
    if comp1 != comp2:
        for i in range(number_of_vertex):
            if vertex_labels[i] == comp2:
                vertex_labels[i] = comp1

mst_edges = []
total_weight = 0

for weight, u, v in edges:
    if find_component(u) != find_component(v):
        mst_edges.append((u, v, weight)) # (вершина1, вершина2, вес)
        total_weight += weight
        union(u, v)

print(f"Суммарный вес дерева: {total_weight}")
for u, v, weight in mst_edges:
    print(f"Ребро {u} - {v} с весом {weight}")
