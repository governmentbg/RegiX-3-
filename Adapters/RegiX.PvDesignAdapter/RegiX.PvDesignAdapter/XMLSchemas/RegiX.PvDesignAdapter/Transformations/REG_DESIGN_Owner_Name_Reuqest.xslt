<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/PatentDepartment/Design/OwnerNameRequest" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<br/>
					<h3 align="center">
						<span>
							<xsl:text>Справка по притежател на промишлен дизайн - входни параметри</xsl:text>
						</span>
					</h3>
					<table style="width:50%; " align="center" border="0" width="100%">
						<tbody>
							<tr>
								<td>
									<span style="font-weight:bold; ">
										<xsl:text>Собствено име</xsl:text>
									</span>
								</td>
								<td>
									<xsl:for-each select="n1:GetDesignByOwnersName">
										<xsl:for-each select="n1:FName">
											<xsl:apply-templates/>
										</xsl:for-each>
									</xsl:for-each>
								</td>
							</tr>
							<tr>
								<td>
									<span style="font-weight:bold; ">
										<xsl:text>Бащино име</xsl:text>
									</span>
								</td>
								<td>
									<xsl:for-each select="n1:GetDesignByOwnersName">
										<xsl:for-each select="n1:SName">
											<xsl:apply-templates/>
										</xsl:for-each>
									</xsl:for-each>
								</td>
							</tr>
							<tr>
								<td>
									<span style="font-weight:bold; ">
										<xsl:text>Фамилно име</xsl:text>
									</span>
								</td>
								<td>
									<xsl:for-each select="n1:GetDesignByOwnersName">
										<xsl:for-each select="n1:LName">
											<xsl:apply-templates/>
										</xsl:for-each>
									</xsl:for-each>
								</td>
							</tr>
						</tbody>
					</table>
					<br/>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
