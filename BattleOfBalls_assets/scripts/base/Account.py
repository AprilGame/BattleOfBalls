# -*- coding: utf-8 -*-
import KBEngine
from KBEDebug import *

class Account(KBEngine.Proxy):
	def __init__(self):
		KBEngine.Proxy.__init__(self)

	#更新玩家昵称
	def updatePlayerName(self,name):
		self.playerNameBase=name
		self.cellData["playerName"] = name

	#更新玩家经验值
	def updatePlayerExp(self,exp):
		self.playerExp+=exp

	#更新玩家模型类型
	def updateModelType(self,type):
		self.cellData["modelType"]=type

		
	#进入个人竞技模式
	def playIndiviGame(self):
		print("match individual game!")
		KBEngine.globalData["Hall"].matchIndiviGame(self)

	#进入大逃杀模式
	def playBattleGame(self):
		print("match battle game!")
		#KBEngine.globalData["Hall"].matchBattleGame(self)

	#进入团队模式
	def playTeamGame(self):
		print("match team game!")
		#KBEngine.globalData["Hall"].matchTeamGame(self)

	#创建玩家cell实体
	def createPlayerCell(self,cellEntityCall):
		self.createCellEntity(cellEntityCall)


	#玩家离开房间
	def playerLeaveRoom(self):
		self.destroyCellEntity()
		
	def onTimer(self, id, userArg):
		"""
		KBEngine method.
		使用addTimer后， 当时间到达则该接口被调用
		@param id		: addTimer 的返回值ID
		@param userArg	: addTimer 最后一个参数所给入的数据
		"""
		DEBUG_MSG(id, userArg)
		
	def onClientEnabled(self):
		"""
		KBEngine method.
		该entity被正式激活为可使用， 此时entity已经建立了client对应实体， 可以在此创建它的
		cell部分。
		"""
		INFO_MSG("account[%i] entities enable. entityCall:%s" % (self.id, self.client))
			
	def onLogOnAttempt(self, ip, port, password):
		"""
		KBEngine method.
		客户端登陆失败时会回调到这里
		"""
		INFO_MSG(ip, port, password)
		return KBEngine.LOG_ON_ACCEPT
		
	def onClientDeath(self):
		"""
		KBEngine method.
		客户端对应实体已经销毁
		"""
		DEBUG_MSG("Account[%i].onClientDeath:" % self.id)
		self.destroy()
