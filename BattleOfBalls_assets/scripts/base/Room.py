# -*- coding: utf-8 -*-
import KBEngine
from KBEDebug import *

class Room(KBEngine.Entity):
	def __init__(self):
		KBEngine.Entity.__init__(self)
		self.createCellEntityInNewSpace(None)
		self.roomID=self.cellData["roomID"]


	#房间创建后，初始化玩家数据
	def onGetCell(self):
		for i in range(len(self.playerList)):
			entity=self.playerList[i]
			entity.updateModelType(i)
			entity.createPlayerCell(self.cell)

	#游戏结束
	def onPlayerGameOver(self):
		for entity in self.playerList:
			entity.client.playerGameOver()