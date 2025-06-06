f = open('example.txt')
lines = f.readlines()
number_of_vertex = len(lines[0].split())

matrix = []
for i in lines:
    line = list(map(int, i.split()))
    matrix.append(line)

graph_copy = []
for row in matrix:
    new_row = []
    for value in row:
        new_row.append(value)
    graph_copy.append(new_row)

max_flow = 0
source = 0
sink = number_of_vertex - 1
parent = [-1] * number_of_vertex

while True:
    visited = [False] * number_of_vertex
    queue = [source]
    visited[source] = True

    while queue:
        u = queue.pop(0)

        for v in range(number_of_vertex):
            if not visited[v] and graph_copy[u][v] > 0:
                queue.append(v)
                visited[v] = True
                parent[v] = u

    if not visited[sink]:
        break

    path_flow = float('inf')
    s = sink
    while s != source:
        path_flow = min(path_flow, graph_copy[parent[s]][s])
        s = parent[s]

    v = sink
    while v != source:
        u = parent[v]
        graph_copy[u][v] -= path_flow
        graph_copy[v][u] += path_flow
        v = parent[v]

    max_flow += path_flow

print("Максимальный поток:", max_flow)
