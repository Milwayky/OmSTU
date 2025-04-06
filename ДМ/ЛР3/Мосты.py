def count_components(matrix, number_of_vertex):
    visited = [False] * number_of_vertex
    counter = 0

    def walk_through(v):
        visited[v] = True
        for i in range(number_of_vertex):
            if matrix[v][i] != 0 and not visited[i]:
                walk_through(i)
        return True

    for i in range(number_of_vertex):
        if not visited[i]:
            walk_through(i)
            counter += 1

    return counter


f = open('example.txt')
lines = f.readlines()
number_of_vertex = len(lines[0].split())

matrix = []
for i in lines:
    line = list(map(int, i.split()))
    matrix.append(line)


edges = []
for i in range(number_of_vertex):
    for j in range(i + 1, number_of_vertex):
        if matrix[i][j] != 0:
            edges.append((i, j))

bridges = []

for u, v in edges:
    temp_matrix = [row[:] for row in matrix]
    temp_matrix[u][v] = 0
    temp_matrix[v][u] = 0

    components_after_removing = count_components(temp_matrix, number_of_vertex)

    if components_after_removing > 1:
        bridges.append((u + 1, v + 1))

print("Мосты в графе:")
for u, v in bridges:
    print(f"{u} - {v}")
