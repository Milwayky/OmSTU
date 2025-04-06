import sys

f = open('example.txt')
lines = f.readlines()
number_of_vertex = len(lines[0].split())

matrix = []
for i in lines:
    line = list(map(int, i.split()))
    matrix.append(line)

start_vertex = int(input(f"Введите начальную вершину от 1 до {number_of_vertex}: "))
min_or_max = input('Введите "min" для минимального поиска или "max" для максимального: ')

initial_vertex = list(range(1, number_of_vertex + 1))
used_vertex = [start_vertex]
initial_vertex.remove(start_vertex)
total_weight = 0
edges = []

while initial_vertex:
    if min_or_max == 'min':
        temporary_weight = sys.maxsize
        temporary_next_vertex = -1
        current_vertex = -1

        for i in used_vertex:
            for j in initial_vertex:
                if matrix[i - 1][j - 1] != 0 and matrix[i - 1][j - 1] < temporary_weight:
                    temporary_next_vertex = j
                    temporary_weight = matrix[i - 1][j - 1]
                    current_vertex = i

        total_weight += temporary_weight
        used_vertex.append(temporary_next_vertex)
        initial_vertex.remove(temporary_next_vertex)
        edges.append((current_vertex, temporary_next_vertex, temporary_weight))

    elif min_or_max == 'max':
        temporary_weight = -sys.maxsize
        temporary_next_vertex = -1
        current_vertex = -1

        for i in used_vertex:
            for j in initial_vertex:
                if matrix[i - 1][j - 1] != 0 and matrix[i - 1][j - 1] > temporary_weight:
                    temporary_next_vertex = j
                    temporary_weight = matrix[i - 1][j - 1]
                    current_vertex = i

        total_weight += temporary_weight
        used_vertex.append(temporary_next_vertex)
        initial_vertex.remove(temporary_next_vertex)
        edges.append((current_vertex, temporary_next_vertex, temporary_weight))

print(f"Суммарный вес дерева: {total_weight}")

for edge in edges:
    print(f"Ребро {edge[0]} - {edge[1]} с весом {edge[2]}")
